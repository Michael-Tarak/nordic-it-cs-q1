using Reminder.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reminder.WebApi.ViewModels
{
	public class PagedViewModel
	{
		public int Total { get; }

		public int TotalPages { get; }

		public int PageNumber { get; }

		public int PageSize { get; }

		public List<ReminderItemViewModel> Items { get; }

		public PagedViewModel(PagedResult result)
		{
			Total = result.Total;
			TotalPages = (int)Math.Ceiling(result.Total * 1.0 / result.Page.Size);
			PageNumber = (int)result.Page.Number;
			PageSize = (int)result.Page.Size;
			Items = result.Items.Select(_ => new ReminderItemViewModel(_)).ToList();
		}
	}
}
