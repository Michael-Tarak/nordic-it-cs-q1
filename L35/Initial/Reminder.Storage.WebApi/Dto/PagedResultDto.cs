using System.Collections.Generic;

namespace Reminder.Storage.WebApi.Dto
{
	internal class PagedResultDto
	{
		public int Total { get; set; }

		public int PageNumber { get; set; }

		public int PageSize { get; set; }

		public List<ReminderItemDto> Items { get; set; }
	}
}
