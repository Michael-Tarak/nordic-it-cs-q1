using System;

namespace Reminder.Domain.Models
{
	public class CreateReminderModel
	{
		public string ContactId { get; set; }
		public string Message { get; set; }
		public DateTimeOffset Datetime { get; set; }

		public CreateReminderModel(
			string contactId,
			string message,
			DateTimeOffset datetime)
		{
            if( string.IsNullOrWhiteSpace(contactId))
            {
                throw new ArgumentNullException("Не указан контакт", nameof(contactId));
            }
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException("Сообщение пустое", nameof(message));
            }
            if (datetime == default)
            {
                throw new ArgumentNullException("Указана неверная дата", nameof(datetime));
            }
            ContactId = contactId;
			Message = message;
			Datetime = datetime;
		}
	}
}
