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
                Console.Write("Введите положительное натуральное число не более 2 миллиардов: ");
                int startNumber = int.Parse(Console.ReadLine());
                if (startNumber <= 0 || 2000000000  < startNumber )
                {
                    throw new OverflowException();
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
                FirstHomeWork();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Введено запредельное значение!");
                FirstHomeWork();
            }
        }
        static void SecondHomeWork()
        {
            try
            {
                Console.Write("Введите сумму первоначального взноса в рублях: ");
                decimal deposition = decimal.Parse(Console.ReadLine());
                if (deposition <= 0)
                {
                    throw new OverflowException();
                }

                Console.Write("Введите ежедневный процент дохода в виде десятичной дроби (1% = 0,01): ");
                decimal stonksPercent = decimal.Parse(Console.ReadLine());
                if (stonksPercent <= 0)
                {
                    throw new OverflowException();
                }

                Console.Write("Введите желаемую сумму накопления в рублях: ");
                decimal stonksResult = decimal.Parse(Console.ReadLine());
                if (stonksResult <= 0)
                {
                    throw new OverflowException();
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
                SecondHomeWork();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Введено некорректное значение!");
                SecondHomeWork();
            }
        }
    }
}
