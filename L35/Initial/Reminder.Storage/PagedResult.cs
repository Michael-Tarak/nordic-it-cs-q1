using System.Collections.Generic;
using System.Linq;

namespace Reminder.Storage
{
	public class PagedResult
	{
		public int Total { get; }

		public PageInfo Page { get; }

		public List<ReminderItem> Items { get; }

		public PagedResult(
			int total, 
			PageInfo page, 
			IEnumerable<ReminderItem> items)
		{
			Total = total;
			Page = page;
			Items = items.ToList();
		}
	}
}
