using System;
using System.ComponentModel.DataAnnotations;
using Reminder.Storage;

namespace Reminder.WebApi.ViewModels
{
	public class ReminderItemFilterViewModel
	{
		[Range(1, int.MaxValue)]
		public int PageNumber { get; set; } = 1;

		[Range(1, 100)]
		public int PageSize { get; set; } = 10;

		public long? DateTimeUtc { get; set; }

		public ReminderItemStatus Status { get; set; }
	}
}
