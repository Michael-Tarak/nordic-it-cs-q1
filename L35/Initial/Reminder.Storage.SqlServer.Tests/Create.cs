using System;

namespace Reminder.Storage.SqlServer.Tests
{
	public static class Create
	{
		public static ReminderItem Item(
			Guid? id = default,
			string contactId = default,
			string message = default,
			DateTimeOffset? datetime = default,
			ReminderItemStatus? status = default)
		{
			return new ReminderItem(
				id ?? Guid.NewGuid(),
				contactId ?? "123",
				message ?? "message",
				datetime ?? DateTimeOffset.UtcNow,
				status ?? ReminderItemStatus.Created);
		}

		public static ReminderStorageBuilder Storage(string connectionString) =>
			new ReminderStorageBuilder(connectionString);
	}
}
