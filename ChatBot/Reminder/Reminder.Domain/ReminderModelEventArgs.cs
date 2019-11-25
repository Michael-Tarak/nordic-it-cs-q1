using System;
using Reminder.Storage;
namespace Reminder.Domain
{
    public class ReminderModelEventArgs : EventArgs
    {
        public string ContactId { get; set; }
        public string Message { get; set; }
        public ReminderModelEventArgs(ReminderItem item)
        {
            ContactId = item.ContactId;
            Message = item.Message;
        }
    }
}