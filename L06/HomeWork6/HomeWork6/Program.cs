using System;

namespace HomeWork6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            string inputOfHomeWork = "";
            while(!string.Equals(inputOfHomeWork, "exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Введите номер домашнего задания: 1, 2. Для выхода из программы введите exit.");
                inputOfHomeWork = Console.ReadLine();
                switch (inputOfHomeWork)
                {
                    case "1":
                        FirstHomeWork();
                        break;
                    case "2":
                        SecondHomeWork();
                        break;
                    case "exit":
                        break;
                    default:
                        Console.WriteLine("Несуществующая команда.");
                        break;
                }
            }
        }
        static void FirstHomeWork()
        {
            try
            {
                int startNumber;
                while (true)
                {
                    Console.Write("Введите положительное натуральное число не более 2 миллиардов: ");

                    if ((int.TryParse(Console.ReadLine(),out startNumber)) && startNumber > 0 && startNumber <= 2000000000)
                    {
                        break;
                    }
                    Console.WriteLine("Неверное число!");
                }
                byte evenCounter = 0;
                int tempNumber = startNumber;
                do
                {
                    int remainder = tempNumber % 2;
                    if (remainder == 0)
                        evenCounter++;
                    tempNumber /= 10;
                }
                while (tempNumber != 0);
                Console.WriteLine($"В числе {startNumber} содержится следующее количество четных цифр: {evenCounter} ");
            }
            catch (FormatException)
            {
                Console.WriteLine("Введено ненатуральное число!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Значение слишком большое!");
            }
        }
        static void SecondHomeWork()
        {
            try
            {
                decimal deposition;
                decimal stonksPercent;
                decimal stonksResult;
                while(true)
                {
                    Console.Write("Введите сумму первоначального взноса в рублях: ");
                    if (decimal.TryParse(Console.ReadLine(), out deposition) && deposition > 0)
                    {
                        break;
                    }
                    Console.WriteLine("Неверное значение!");
                }
                while (true)
                {
                    Console.Write("Введите ежедневный процент дохода в виде десятичной дроби (1% = 0,01): ");
                    if (decimal.TryParse(Console.ReadLine(),out stonksPercent) && stonksPercent > 0)
                    {
                        break;
                    }
                    Console.WriteLine("Неверное значение!");
                }
                while(true)
                {
                    Console.Write("Введите желаемую сумму накопления в рублях: ");
                    if (decimal.TryParse(Console.ReadLine(), out stonksResult) && stonksResult > 0)
                    {
                        break;
                    }
                    Console.WriteLine("Неверное значение!");
                }
                int dayCounter = 0;
                while(deposition < stonksResult)
                {
                    deposition *=(1 + stonksPercent);
                    dayCounter++;
                }
                Console.WriteLine($"Необходимое количество дней для накопления желаемой суммы : {dayCounter}");
            }
            catch (FormatException)
            {
                Console.WriteLine("В вводе обнаружен символ!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Значение слишком большое!");
            }
        }
    }
}
