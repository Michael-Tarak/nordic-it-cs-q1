using System;
using System.Collections.Generic;

namespace HomeWork12
{
    class Program
    {
        static void Main(string[] args)
        {
            var reminders = new List<ReminderItem>();
            var reminder1 = new ReminderItem(DateTimeOffset.Parse("16-04-2020"), "Wake up, samurai");
            var reminder2 = new PhoneReminderItem(DateTimeOffset.Parse("4:20"), "You know what time it is", "88005553535");
            var reminder3 = new ChatReminderItem(DateTimeOffset.Parse("11-09-2020"),"Grandma\'s birthday", "Family\'s chat","<Everyone>");
            reminders.Add(reminder1);
            reminders.Add(reminder2);
            reminders.Add(reminder3);
            foreach(var reminder in reminders)
            {
                reminder.WriteProperties();
                Console.WriteLine("");
            }
        }
    }
}
