using System;

namespace ClassWork7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("Введите первый символ");
            double firstOperand = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите второй символ");
            double secondOperand = double.Parse(Console.ReadLine());
            Console.WriteLine($"{firstOperand:#.##} * {secondOperand:#.##} = {firstOperand * secondOperand:#.##}");
            Console.WriteLine($"{firstOperand:#.##} + {secondOperand:#.##} = {firstOperand + secondOperand:#.##}");
            Console.WriteLine($"{firstOperand:#.##} - {secondOperand:#.##} = {firstOperand - secondOperand:#.##}");



        }
    }
}
