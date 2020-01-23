using System.ComponentModel.DataAnnotations;
using Reminder.Storage;

namespace Reminder.WebApi.ViewModels
{
	public class UpdateReminderItemViewModel
	{
		[Required]
		[MaxLength(2048)]
		public string Message { get; set; }

		public long DateTimeUtc { get; set; }

		public ReminderItemStatus Status { get; set; }
	}
}
