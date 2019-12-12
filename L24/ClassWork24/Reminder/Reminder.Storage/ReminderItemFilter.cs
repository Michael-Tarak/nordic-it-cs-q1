using System;

namespace Reminder.Storage
{
	public class ReminderItemFilter
	{
        public ReminderItemFilter(DateTimeOffset? dateTime = default, ReminderItemStatus? status = default)
        {
            DateTime = dateTime;
            Status = status;
        }

        public DateTimeOffset? DateTime { get; private set; }
		public ReminderItemStatus? Status { get; private set; }

		public ReminderItemFilter At(DateTimeOffset datetime)
		{
			DateTime = datetime;
			return this;
		}

		public static ReminderItemFilter ByStatus(ReminderItemStatus status )
		{
            return new ReminderItemFilter(status: status);
		}
	}
}
