using System;

namespace HomeWork11
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer1 = new ReminderItem(DateTimeOffset.Parse("30-09-2019"), "Time to get a job");
            var timer2 = new ReminderItem(DateTimeOffset.Parse("09:00"), "Go to study");
            timer1.WriteProperties();
            timer2.WriteProperties();
            Console.ReadKey();
        }
    }
}
