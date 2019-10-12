using System;
using System.Collections.Generic;

namespace ClassWork8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            var countriesAndCapitals = new Dictionary<string, string>
            {
                ["Россия"] = "Москва",
                ["США"] = "Вашингтон",
                ["Великобритания"] = "Лондон",
                ["Румыния"] = "Бухарест",
                ["Болгария"] = "София"
            };
            bool answer = true;
            while(answer)
            {
                var random = new Random();
                var question = random.Next(0, countriesAndCapitals.Count);
                Console.WriteLine($"Напишите столицу {countriesAndCapitals[question]}");
            }
        }
    }
}
