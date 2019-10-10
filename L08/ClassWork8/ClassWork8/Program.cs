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
            string input;
            var firstList = new List<double>();
            try
            {
                double sum = 0;
                double result = 0;
                while (true)
                {
                    Console.WriteLine("Введите число, для остановки введите stop");
                    input = Console.ReadLine();
                    if (input == "stop")
                    {
                        for (int i = 0; i < firstList.Count; i++)
                        {
                            sum += firstList[i];
                        }
                        result = sum / (double)firstList.Count;
                        break;

                    }
                    firstList.Add(double.Parse(input));
                }
                Console.WriteLine($" Ответ: {result}");

            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка ввода!");
            }
            
        }
    }
}
