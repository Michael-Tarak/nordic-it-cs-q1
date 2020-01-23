using System;

namespace Reminder.Storage.Exceptions
{
	public class ReminderItemDuplicateException : Exception
	{
		public ReminderItemDuplicateException(Guid id, Exception inner = default) :
			base($"Reminder item with id {id} already exists", inner)
		{
		}

		public ReminderItemDuplicateException(string message) :
			base(message)
		{
		}
	}
}
