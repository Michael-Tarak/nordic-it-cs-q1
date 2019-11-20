using System;

namespace Reminder.Storage
{
    public class ReminderItemFilter
    {
        public DateTimeOffset? DateTime { get; set; }
        public ReminderItemStatus? Status { get; private set; }

        public ReminderItemFilter (DateTimeOffset datetime)
        {
            DateTime = datetime;
            return this;
        }
        public ReminderItemFilter
    }
}
