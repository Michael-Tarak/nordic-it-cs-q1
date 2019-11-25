using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Reminder.Receiver.Telegram
{
    public class ReminderReceiver : IReminderReceiver
    {
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;
        private readonly TelegramBotClient _client;
        public ReminderReceiver(string token)
        {
            _client = new TelegramBotClient(token);
            _client.OnMessage += OnMessage;
        }

        private void OnMessage(object sender, MessageEventArgs args)
        {
            var contactId = args.Message.From.Username;
            var text = args.Message.Text;
            var (message, error) = Message.TryParse(args.Message.Text);
            if(string.IsNullOrWhiteSpace(error))
            {
                MessageReceived?.Invoke(this, new MessageReceivedEventArgs(contactId, message));
            }
        }
    }
}
