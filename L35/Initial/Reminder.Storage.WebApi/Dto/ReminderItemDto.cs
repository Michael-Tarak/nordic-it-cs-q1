using System;

namespace Reminder.Storage.WebApi.Dto
{
	internal class ReminderItemDto
	{
		public string Id { get; set; }

		public string ContactId { get; set; }

		public string Message { get; set; }

		public long DateTimeUtc { get; set; }

		public ReminderItemStatus Status { get; set; }

		public ReminderItemDto()
		{
		}

		public ReminderItemDto(ReminderItem item)
		{
			Id = item.Id.ToString("N");
			ContactId = item.ContactId;
			Message = item.Message;
			DateTimeUtc = item.DatetimeUtc.ToUnixTimeMilliseconds();
			Status = item.Status;
		}

		public ReminderItem ToItem() => 
			new ReminderItem(
				Guid.Parse(Id),
				ContactId,
				Message,
				DateTimeOffset.FromUnixTimeMilliseconds(DateTimeUtc),
				Status
			);
	}
}
