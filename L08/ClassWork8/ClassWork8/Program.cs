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
                        SecondClassWork();
                        break;
                    case "3":
                        ThirdClassWork();
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
        static void SecondClassWork()
        {
            var numbers = new Queue<int> { };
            while(true)
            {
                Console.WriteLine("Введите число, либо команду");
                var input = Console.ReadLine();
                if(Int32.TryParse(input, out int numberValue))
                {
                    numbers.Enqueue(numberValue);
                    continue;
                }
                if (input == "run")
                {
                    while(numbers.Count > 0)
                    {
                        Console.WriteLine(Math.Sqrt(numbers.Dequeue())); //Тут вопрос: почему мне не выдает ошибку, ведь метод 
                    }                                                    // double, а на ввод идет int?
                    continue;
                }
                if (input == "exit")
                {
                    Console.WriteLine($"В очереди на квадрат осталось {numbers.Count} значений");
                    break;
                }
                Console.WriteLine("Неправильное значение, либо несуществующая команда!");
            }

        }
        static void ThirdClassWork()
        {
            var plateStack = new Stack<bool> { };
            var whileBreaker = false;
            while(!whileBreaker)
            {
                Console.WriteLine("Введите команду wash, dry или exit");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "wash":
                        plateStack.Push(true);
                        break;
                    case "dry":
                        if (plateStack.Count == 0)
                        {
                            Console.WriteLine("Стопка тарелок пуста!");
                            break;
                        }
                        plateStack.Pop();
                        break;
                    case "exit":
                        whileBreaker = true;
                        break;
                    default:
                        break;
                }
                Console.WriteLine($"Количество тарелок в стопке - {plateStack.Count}");
            }
        }
    }
}
