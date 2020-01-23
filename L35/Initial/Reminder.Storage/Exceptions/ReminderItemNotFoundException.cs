using System;

namespace Reminder.Storage.Exceptions
{
	public class ReminderItemNotFoundException : Exception
	{
		public ReminderItemNotFoundException(Guid id, Exception inner = default) :
			base($"Reminder item with id {id} not found", inner)
		{
		}

		public ReminderItemNotFoundException(string message) :
			base(message)
		{
		}
	}
}
