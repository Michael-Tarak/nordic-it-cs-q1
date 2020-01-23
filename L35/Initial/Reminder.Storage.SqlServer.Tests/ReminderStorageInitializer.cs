using Microsoft.Data.SqlClient;
using System.Linq;

namespace Reminder.Storage.SqlServer.Tests
{
	public class ReminderStorageInitializer
	{
		private readonly string _connectionString;

		public ReminderStorageInitializer(string connectionString)
		{
			_connectionString = connectionString;
		}

		public void CreateTables()
		{
			using var connection = _connectionString.ToSqlConnection();

			ExecuteScripts(
				connection, 
				Sql.CreateContactTable, 
				Sql.CreateReminderItemStatusTable, 
				Sql.InsertReminderItemStatusLines, 
				Sql.CreateReminderItemTable
			);
		}

		public void CreateStoredProcedures()
		{
			using var connection = _connectionString.ToSqlConnection();

			ExecuteScripts(
				connection, 
				Sql.AddReminderItem,
				Sql.UpdateReminderItem,
				Sql.DeleteReminderItem
			);
		}

		public void DropTables()
		{
			using var connection = _connectionString.ToSqlConnection();

			var scripts = new[] { "ReminderItem", "ReminderItemStatus", "Contact" }
				.Select(name => $"DROP TABLE IF EXISTS [{name}];")
				.ToArray();

			ExecuteScripts(connection, scripts);
		}

		public void DropStoredProcedures()
		{
			using var connection = _connectionString.ToSqlConnection();

			var scripts = new[] { "sp_AddReminderItem", "sp_UpdateReminderItem", "sp_DeleteReminderItem" }
				.Select(name => $"DROP PROCEDURE IF EXISTS [{name}];")
				.ToArray();

			ExecuteScripts(connection, scripts);
		}

		private void ExecuteScripts(SqlConnection connection, params string[] scripts)
		{
			foreach (var script in scripts)
			{
				using var command = connection.CreateQuery(script);
				command.ExecuteNonQuery();
			}
		}
	}
}
