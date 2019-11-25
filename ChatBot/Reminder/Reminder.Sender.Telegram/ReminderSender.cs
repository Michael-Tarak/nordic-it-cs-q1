using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Reminder.Sender.Telegram
{
    public class ReminderSender : IReminderSender
    {
        public readonly TelegramBotClient _client;
        public ReminderSender(string token)
        {
            _client = new TelegramBotClient(token);
        }
        public void Send(Notification notification)
        {
            var chatId = new ChatId(notification.ContactId);
            _client.SendTextMessageAsync(chatId, notification.Message);
        }
    }
}
