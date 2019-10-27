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
            Console.WriteLine(typeof(ChatReminderItem));
            Console.WriteLine($"AlarmDate : {AlarmDate}");
            Console.WriteLine($"AlarmMessage: {AlarmMessage}");
            Console.WriteLine($"TimeToAlarm: {TimeToAlarm}");
            Console.WriteLine($"IsOutdated: {IsOutdated}");
            Console.WriteLine($"ChatName: {ChatName}");
            Console.WriteLine($"ChatMessage: {ChatMessage}");
        }
    }
}
