using Reminder.Domain;
using Reminder.Receiver.Telegram;
using Reminder.Sender.Telegram;
using Reminder.Storage.Memory;
using System;

namespace Reminder
{
    class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("[Reminder Notifier] starting...");
            var key = "";
            var sender = new ReminderSender(key);
            var receiver = new ReminderReceiver(key);
            var service = new ReminderService(
                new ReminderStorage(),
                sender,
                receiver,
                new ReminderServiceParameters());
            Console.ReadKey();
            Console.WriteLine("[Reminder Notifier] completed");
        }
    }
}