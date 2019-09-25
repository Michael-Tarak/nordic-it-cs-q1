using System;
using System.Text;
namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.InputEncoding = Encoding.UTF8;
            //Console.OutputEncoding = Encoding.UTF8;
            //Console.WriteLine("Введите первое число");
            //long firstOperand = Convert.ToInt64(Console.ReadLine());
            //Console.WriteLine("Введите второе число");
            //long secondOperand = Convert.ToInt64(Console.ReadLine());
            //Console.WriteLine($"{firstOperand} + {secondOperand} = {firstOperand + secondOperand}");
            //Console.WriteLine($"{firstOperand} - {secondOperand} = {firstOperand - secondOperand}");
            //Console.WriteLine($"{firstOperand} * {secondOperand} = {firstOperand * secondOperand}");
            Hardmode();
        }
        static void CalculationOperation(long x, long y)
        {
            Console.WriteLine("Выберите тип операции: сложение +, разность -, умножение *, деление(остаток отбрасывается) /,\n остаток от деления %, возведение в степень ^");
            string operation1 = Console.ReadLine();
            switch (operation1)
            {
                case "+":
                    Console.WriteLine($"{x} + {y} = {x + y}");
                    break;
                case "-":
                    Console.WriteLine($"{x} - {y} = {x - y}"); ;
                    break;
                case "*":
                    Console.WriteLine($"{x} * {y} = {x * y}");
                    break;
                case "/":
                    Console.WriteLine($"{x} / {y} = { x / y}");
                    break;
                case "^":
                    Console.WriteLine($"{x} ^ {y} = { Convert.ToInt64(Math.Pow(Convert.ToDouble(x), Convert.ToDouble(y)))}");
                    break;
                case "%":
                    Console.WriteLine($"{x} % {y} = {x % y}");
                    break;
                default:
                    Console.WriteLine("Запрашивается несуществующая операция, повторите попытку");
                    CalculationOperation(x, y);
                    break;
            }
        }

        static void Hardmode()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                Console.WriteLine("Введите первое число");
                long firstOperand = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Введите второе число");
                long secondOperand = Convert.ToInt64(Console.ReadLine());
                CalculationOperation( firstOperand , secondOperand );
            }
            catch (FormatException)
            {
                Console.WriteLine("Такого числа не существует, введите число заново");
                Hardmode();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Число слишком большое, либо слишком малое");
                Hardmode();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Попытка деления на ноль");
                Hardmode();
            }
        }
    }
}
