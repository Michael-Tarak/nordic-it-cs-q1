using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassWork8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            while(true)
            {
                Console.Write("ВЫберите номер самостоятельной работы: ");
                var input = Console.ReadLine();
                if (input == "exit")
                    break;
                switch (input)
                {
                    case "1":
                        FirstClassWork();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Неправильный номер работы");
                        break;
                }
            }
        }

        private static void FirstClassWork()
        {
            var countriesAndCapitals = new Dictionary<string, string>
            {
                ["Россия"] = "Москва",
                ["США"] = "Вашингтон",
                ["Великобритания"] = "Лондон",
                ["Румыния"] = "Бухарест",
                ["Болгария"] = "София",
                ["Венгрия"] = "Будапешт",
                ["Чехия"] = "Прага",
                ["Германия"] = "Берлин"
            };
            var rightCounter = 0;
            while (true)
            {
                var random = (new Random()).Next(countriesAndCapitals.Count);
                KeyValuePair<string, string> cac = countriesAndCapitals.ElementAtOrDefault(random);
                var country = cac.Key;
                var capital = cac.Value;
                Console.Write($"Напишите название столицы страны \"{country}\": ");
                var answer = Console.ReadLine();
                answer.Trim();
                if (answer != capital)
                {
                    Console.WriteLine($"Ответ неверный, вы проиграли. Вы отгдали {rightCounter} столиц");
                    break;
                }
                else
                {
                    Console.WriteLine("Ответ правильный!");
                    rightCounter++;
                }
            }
        }
    }
}
