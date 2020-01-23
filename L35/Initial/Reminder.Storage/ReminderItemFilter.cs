using System;

namespace Reminder.Storage
{
	public class ReminderItemFilter
	{
		public DateTimeOffset DatetimeUtc { get; }

		public ReminderItemStatus Status { get; }

		public PageInfo Page { get; }

		public bool ByDatetime =>
			DatetimeUtc != default;

		public bool ByStatus =>
			Status != ReminderItemStatus.Undefied;

		public ReminderItemFilter(
			PageInfo page = default,
			DateTimeOffset datetimeUtc = default,
			ReminderItemStatus status = ReminderItemStatus.Undefied)
		{
			Page = page ?? PageInfo.All;
			DatetimeUtc = datetimeUtc;
			Status = status;
		}
	}
}
