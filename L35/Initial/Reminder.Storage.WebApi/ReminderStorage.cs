using System;
using System.Net;
using System.Net.Http;
using Reminder.Storage.Exceptions;

namespace Reminder.Storage.WebApi
{
	public class ReminderStorage : IReminderStorage
	{
		private const string ApiPrefix = "/api/reminders";
		private readonly HttpClient _client;

		public ReminderStorage(HttpClient client)
		{
			_client = client;
		}

		public void Add(ReminderItem item) => 
			ExecuteRequest(ApiPrefix, HttpMethod.Post, item.Json());

		public void Update(ReminderItem item) => 
			ExecuteRequest($"{ApiPrefix}/{item.Id}", HttpMethod.Put, item.Json());

		public void Delete(Guid id) => 
			ExecuteRequest($"{ApiPrefix}/{id}", HttpMethod.Delete);

		public void Clear() =>
			ExecuteRequest($"{ApiPrefix}/prune", HttpMethod.Post);

		public ReminderItem FindById(Guid id) => ExecuteRequest($"{ApiPrefix}/{id}", HttpMethod.Get)
			.Content
			.ReminderItem();

		public PagedResult FindBy(ReminderItemFilter filter) => ExecuteRequest($"{ApiPrefix}?{filter.QueryString()}", HttpMethod.Get)
			.Content
			.ReminderItemPage();

		private HttpResponseMessage ExecuteRequest(
			string url,
			HttpMethod method,
			StringContent content = default)
		{
			var request = new HttpRequestMessage(method, url)
			{
				Content = content
			};

			var response = _client.SendAsync(request)
				.GetAwaiter()
				.GetResult();

			// Фича C# 8.0 называемая switch return expressions
			// Позволяет конструкцию вида
			// swith(..)
			// {
			//    case value: 
			//      return ...;
			// }
			// То есть, когда все метки действий либо возвращают значение, либо генерируют исключения
			// Переписать в более лаконичный и выразительный вариант
			// Здесь, метка _ это аналог метки default

			return response.StatusCode switch
			{
				HttpStatusCode.NotFound => throw new ReminderItemNotFoundException($"Reminder item on uri {url} is not found"),
				HttpStatusCode.Conflict => throw new ReminderItemDuplicateException($"Reminder item on uri {url} already exists"),
				_ => response.EnsureSuccessStatusCode(),
			};
		}
	}
}
