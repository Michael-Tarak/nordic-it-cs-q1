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
            base.WriteProperties();
            Console.WriteLine($"PhoneNumber: {PhoneNumber}");
        }
    }
}
