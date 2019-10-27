using System;
namespace HomeWork12
{
    class ReminderItem
    {
        public ReminderItem(DateTimeOffset alarmDate, string alarmMessage)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
        }
        public DateTimeOffset AlarmDate { get; set; }
        public string AlarmMessage { get; set; }
        public TimeSpan TimeToAlarm =>
            DateTime.Now - AlarmDate;
        public bool IsOutdated =>
            DateTime.Now - AlarmDate >= TimeSpan.Zero;
        public virtual void WriteProperties()
        {
            Console.WriteLine(typeof(ReminderItem));
            Console.WriteLine($"AlarmDate : {AlarmDate}");
            Console.WriteLine($"AlarmMessage: {AlarmMessage}");
            Console.WriteLine($"TimeToAlarm: {TimeToAlarm}");
            Console.WriteLine($"IsOutdated: {IsOutdated}");
        }
    }
}
