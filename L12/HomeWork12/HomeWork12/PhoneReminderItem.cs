using System;
namespace HomeWork12
{
    class PhoneReminderItem :ReminderItem
    {
        public PhoneReminderItem(DateTimeOffset alarmDate, string alarmMessage,string phoneNumber)
            :base(alarmDate, alarmMessage)
        {
            PhoneNumber = phoneNumber;
        }
        public  string PhoneNumber { get; set; }
        public override void WriteProperties()
        {
            Console.WriteLine(typeof(PhoneReminderItem));
            Console.WriteLine($"AlarmDate : {AlarmDate}");
            Console.WriteLine($"AlarmMessage: {AlarmMessage}");
            Console.WriteLine($"TimeToAlarm: {TimeToAlarm}");
            Console.WriteLine($"IsOutdated: {IsOutdated}");
            Console.WriteLine($"PhoneNumber: {PhoneNumber}");
        }
    }
}
