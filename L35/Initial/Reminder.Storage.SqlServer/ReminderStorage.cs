using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Reminder.Storage.Exceptions;

namespace Reminder.Storage.SqlServer
{
	public class ReminderStorage : IReminderStorage
	{
		public readonly string _connectionString;

		public ReminderStorage(string connectionString)
		{
			if (string.IsNullOrWhiteSpace(connectionString))
			{
				throw new ArgumentException("Connection string is null or empty", nameof(connectionString));
			}

			_connectionString = connectionString;
		}

		public void Add(ReminderItem item)
		{
			using var connection = _connectionString.ToSqlConnection();
			using var command = connection.CreateStoredProcedure("sp_AddReminderItem");

			command.Parameters.AddWithValue("@p_id", item.Id);
			command.Parameters.AddWithValue("@p_contact", item.ContactId);
			command.Parameters.AddWithValue("@p_status", (byte) item.Status);
			command.Parameters.AddWithValue("@p_datetimeUtc", item.DatetimeUtc);
			command.Parameters.AddWithValue("@p_message", item.Message);

			try
			{
				command.ExecuteNonQuery();
			}
			catch (SqlException exception) 
				when (exception.Number == 2627 && 
					  exception.Message.Contains("PRIMARY KEY", StringComparison.OrdinalIgnoreCase))
			{
				throw new ReminderItemDuplicateException(item.Id, exception);
			}
		}

		public void Update(ReminderItem item)
		{
			using var connection = _connectionString.ToSqlConnection();
			using var command = connection.CreateStoredProcedure("sp_UpdateReminderItem");

			command.Parameters.AddWithValue("@p_id", item.Id);
			command.Parameters.AddWithValue("@p_status", (byte)item.Status);
			command.Parameters.AddWithValue("@p_datetimeUtc", item.DatetimeUtc);
			command.Parameters.AddWithValue("@p_message", item.Message);

			using var reader = command.ExecuteReader();
			_ = reader.Read();

			if (!reader.GetBoolean(reader.GetOrdinal("IsUpdated")))
			{
				throw new ReminderItemNotFoundException(item.Id);
			}
		}

		public ReminderItem FindById(Guid id)
		{
			using var connection = _connectionString.ToSqlConnection();
			using var command = connection.CreateQuery(Sql.FindReminderItem.Replace("{id}", id.ToString()));

			var items = ReadItems(command);
			if (items.Count == 0)
			{
				throw new ReminderItemNotFoundException(id);
			}
			return items[0];
		}

		public PagedResult FindBy(ReminderItemFilter filter)
		{
			using var connection = _connectionString.ToSqlConnection();

			var predicates = QueryBuilder.From(filter);
			using var queryCount = connection.CreateQuery(Sql
				.FindReminderItemsCount
				.Replace("{filter}", predicates));

			var count = ReadCount(queryCount);
			if (count == 0)
			{
				return new PagedResult(count, filter.Page, Enumerable.Empty<ReminderItem>());
			}

			using var queryItems = connection.CreateQuery(Sql
				.FindReminderItems
				.Replace("{filter}", predicates)
				.Replace("{offset}", filter.Page.Offset.ToString())
				.Replace("{limit}", filter.Page.Limit.ToString()));

			return new PagedResult(count, filter.Page, ReadItems(queryItems));
		}

		public void Delete(Guid id)
		{
			using var connection = _connectionString.ToSqlConnection();
			using var command = connection.CreateStoredProcedure("sp_DeleteReminderItem");

			command.Parameters.AddWithValue("@p_id", id);

			using var reader = command.ExecuteReader();
			var read = reader.Read();
			var count = reader.GetInt32(reader.GetOrdinal("DeletedCount"));

			if (count != 1)
			{
				throw new ReminderItemNotFoundException(id);
			}
		}

		public void Clear()
		{
			using var connection = _connectionString.ToSqlConnection();
			using var command = connection.CreateQuery(Sql.TruncateReminderItems);

			command.ExecuteNonQuery();
		}

		private List<ReminderItem> ReadItems(SqlCommand command)
		{
			using var reader = command.ExecuteReader();

			var id = reader.GetOrdinal("Id");
			var login = reader.GetOrdinal("Login");
			var message = reader.GetOrdinal("Message");
			var datetime = reader.GetOrdinal("DatetimeUtc");
			var status = reader.GetOrdinal("StatusId");
			var items = new List<ReminderItem>();

			while (reader.Read())
			{
				var item = new ReminderItem(
					reader.GetGuid(id),
					reader.GetString(login),
					reader.GetString(message),
					reader.GetDateTimeOffset(datetime),
					(ReminderItemStatus)reader.GetByte(status)
				);
				items.Add(item);
			}

			return items;
		}

		private int ReadCount(SqlCommand command)
		{
			using var reader = command.ExecuteReader();

			while (reader.Read())
			{
				return reader.GetInt32(reader.GetOrdinal("Count"));
			}

			return default;
		}
	}
}
