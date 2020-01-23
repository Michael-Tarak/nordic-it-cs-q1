using System.Collections.Generic;
using System.Text;

namespace Reminder.Storage.SqlServer
{
	internal class QueryBuilder
	{
		private readonly List<(string predicte, string filter)> _filters = new List<(string predicte, string filter)>();

		public void And(string filter) => 
			_filters.Add(("AND", filter));

		public void Or(string filter) => 
			_filters.Add(("OR", filter));

		public override string ToString()
		{
			var result = new StringBuilder();

			foreach (var (predicate, filter) in _filters)
			{
				result.Append(
					result.Length > 0
						? $" {predicate} {filter}" 
						: filter
				);
			}

			if (result.Length > 0)
			{
				result.Insert(0, "WHERE ");
			}

			return result.ToString();
		}

		public static string From(ReminderItemFilter filter)
		{
			var queryBuilder = new QueryBuilder();

			if (filter.ByDatetime)
			{
				queryBuilder.And($"RI.DatetimeUtc < '{filter.DatetimeUtc:u}'");
			}

			if (filter.ByStatus)
			{
				queryBuilder.And($"RI.StatusId = {filter.Status:D}");
			}

			return queryBuilder.ToString();
		}
	}
}
