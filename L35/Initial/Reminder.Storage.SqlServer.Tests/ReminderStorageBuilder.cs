using System;

namespace Reminder.Storage.SqlServer.Tests
{
	public class ReminderStorageBuilder
	{
		public string ConnectionString { get; }

		public ReminderItem[] Items { get; private set; } =
			Array.Empty<ReminderItem>();

		public ReminderStorageBuilder(string connectionString)
		{
			ConnectionString = connectionString;
		}

		public ReminderStorageBuilder WithItems(params ReminderItem[] items)
		{
			if (items != default)
			{
				Items = items;
			}
			return this;
		}

		public ReminderStorage Build()
		{
			var storage = new ReminderStorage(ConnectionString);

			foreach (var item in Items)
			{
				storage.Add(item);
			}

			return storage;
		}
	}
}
