using System.Collections.Generic;
using System.Data;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.FileProviders;

namespace Reminder.Storage.SqlServer
{
	internal static class Sql
	{
		public static SqlConnection ToSqlConnection(this string connectionString)
		{
			var connection = new SqlConnection(connectionString);
			connection.Open();
			return connection;
		}

		public static SqlCommand CreateStoredProcedure(this SqlConnection connection, string name)
		{
			var cmd = connection.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = name;
			return cmd;
		}

		public static SqlCommand CreateQuery(this SqlConnection connection, string query)
		{
			var cmd = connection.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = query;
			return cmd;
		}

		public static string CreateReminderItemTable =>
			GetOrAdd(nameof(CreateReminderItemTable));

		public static string CreateReminderItemStatusTable =>
			GetOrAdd(nameof(CreateReminderItemStatusTable));

		public static string CreateContactTable =>
			GetOrAdd(nameof(CreateContactTable));

		public static string InsertReminderItemStatusLines =>
			GetOrAdd(nameof(InsertReminderItemStatusLines));

		public static string AddReminderItem =>
			GetOrAdd(nameof(AddReminderItem));

		public static string FindReminderItem =>
			GetOrAdd(nameof(FindReminderItem));

		public static string FindReminderItems =>
			GetOrAdd(nameof(FindReminderItems));

		public static string FindReminderItemsCount =>
			GetOrAdd(nameof(FindReminderItemsCount));

		public static string UpdateReminderItem =>
			GetOrAdd(nameof(UpdateReminderItem));

		public static string DeleteReminderItem =>
			GetOrAdd(nameof(DeleteReminderItem));

		public static string TruncateReminderItems =>
			GetOrAdd(nameof(TruncateReminderItems));

		private static string GetOrAdd(string filename)
		{
			if (Cache.TryGetValue(filename, out var script))
			{
				return script;
			}
			return Cache[filename] = ReadScript(filename);
		}

		private static string ReadScript(string filename)
		{
			var embeddedProvider = new EmbeddedFileProvider(typeof(Sql).Assembly);
			var fileInfo = embeddedProvider.GetFileInfo($"Scripts\\{filename}.sql");

			using var stream = fileInfo.CreateReadStream();
			using var reader = new StreamReader(stream);

			return reader.ReadToEnd();
		}

		private static readonly Dictionary<string, string> Cache =
			new Dictionary<string, string>();
	}
}
