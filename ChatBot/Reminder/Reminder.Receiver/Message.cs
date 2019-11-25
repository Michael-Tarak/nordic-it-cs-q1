using System;
namespace Reminder.Receiver
{
    public class Message
    {
        public Message(string message, DateTimeOffset datetime)
        {
            Text = message;
            Datetime = datetime;
        }

        public string Text { get; set; }
        public DateTimeOffset Datetime { get; set; }
        public static (Message message, string error) TryParse(string message)
        {
            if(string.IsNullOrWhiteSpace(message))
            {
                return (null, "Строка пустая");
            }
            var separartorIndex = message.IndexOf(",", StringComparison.Ordinal);
            if(separartorIndex < 0)
            {
                return (null, "Отсутствует разделитель");
            }
            var text = message.Substring(0, separartorIndex);
            if(string.IsNullOrWhiteSpace(text))
            {
                return (null, "Отсутствует текст сообщения");
            }
            if(!DateTimeOffset.TryParse(message.Substring(separartorIndex + 1), out var datetime))
            {
                return (null, "Отсутствует дата");
            }
            return (new Message(text, datetime), null);
        }
    }
}