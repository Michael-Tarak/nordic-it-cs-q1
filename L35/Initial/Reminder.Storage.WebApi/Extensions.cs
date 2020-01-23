using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Reminder.Storage.WebApi.Dto;

namespace Reminder.Storage.WebApi
{
	internal static class Extensions
	{
		private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		};

		public static StringContent Json(this ReminderItem item)
		{
			var dto = new ReminderItemDto(item);
			var json = JsonSerializer.Serialize(dto);
			return new StringContent(json, Encoding.UTF8, "application/json");
		}

		public static string QueryString(this ReminderItemFilter filter) => 
			$"pageNumber={filter.Page.Number}&pageSize={filter.Page.Size}&status={filter.Status}&datetimeUtc={filter.DatetimeUtc.ToUnixTimeMilliseconds()}";

		public static ReminderItem ReminderItem(this HttpContent content)
		{
			var json = content.ReadAsStringAsync()
				.GetAwaiter()
				.GetResult();
			return JsonSerializer.Deserialize<ReminderItemDto>(json, Options).ToItem();
		}

		public static PagedResult ReminderItemPage(this HttpContent content)
		{
			var json = content.ReadAsStringAsync()
				.GetAwaiter()
				.GetResult();
			var dto = JsonSerializer.Deserialize<PagedResultDto>(json, Options);
			
			return new PagedResult(
				total: dto.Total,
				page: new PageInfo(
					(uint)dto.PageNumber,
					(uint)dto.PageSize),
				items: dto.Items.Select(_ => _.ToItem())
			);
		}
	}
}
