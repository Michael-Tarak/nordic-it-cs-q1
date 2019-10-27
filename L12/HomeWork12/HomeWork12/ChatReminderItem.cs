using System;
namespace HomeWork12
{
    class ChatReminderItem :ReminderItem
    {
        public ChatReminderItem (DateTimeOffset alarmDate, string alarmMessage, string chatName, string chatMessage)
            :base(alarmDate,alarmMessage)
        {
            ChatName = chatName;
            ChatMessage = chatMessage;
        }
        public string ChatName { get; set; }
        public string ChatMessage { get; set; }
        public override void WriteProperties()
        {
            base.WriteProperties();
            Console.WriteLine($"ChatName: {ChatName}");
            Console.WriteLine($"ChatMessage: {ChatMessage}");
        }
    }
}
