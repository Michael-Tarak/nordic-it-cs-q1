using System.ComponentModel.DataAnnotations;
using Reminder.Storage;

namespace Reminder.WebApi.ViewModels
{
	public class CreateReminderItemViewModel
	{
		[MaxLength(32)]
		public string Id { get; set; }

		[Required]
		[MaxLength(256)]
		public string ContactId { get; set; }

		[Required]
		[MaxLength(2048)]
		public string Message { get; set; }

		public long DateTimeUtc { get; set; }

		public ReminderItemStatus Status { get; set; }
	}
}
