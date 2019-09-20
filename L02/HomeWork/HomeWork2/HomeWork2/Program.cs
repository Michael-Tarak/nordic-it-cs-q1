using System;
using System.Text;
namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Введите первое число");
            long a = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Введите второе число");
            long b = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine($"{a} + {b} = {a + b}");
            Console.WriteLine($"{a} - {b} = {a - b}");
            Console.WriteLine($"{a} * {b} = {a * b}");
            Hardmode();
        }
        static void Hardmode()
        {
            void CalculationOperation( long x, long y )
            {
                Console.WriteLine("Выберите тип операции: сложение +, разность -, умножение *, деление(остаток отбрасывается) /, остаток от деления %, возведение в степень ^");
                string c = Console.ReadLine();
                long d;
                if (c == "+")
                {
                    Console.WriteLine($"{x} + {y} = {d = x + y}");
                }
                else
                {
                    if (c == "-")
                    {
                        Console.WriteLine($"{x} - {y} = {d = x - y}"); ;
                    }
                    else
                    {
                        if (c == "*")
                        {
                            Console.WriteLine($"{x} * {y} = {d = x * y}");
                        }
                        else
                        {
                            if (c == "/")
                            {
                                Console.WriteLine($"{x} / {y} = {d = x / y}");
                            }
                            else
                            {
                                if (c == "^")
                                {
                                    Console.WriteLine($"{x} ^ {y} = {d = Convert.ToInt64(Math.Pow(Convert.ToDouble(x), Convert.ToDouble(y)))}");
                                }
                                else
                                {
                                    if(c == "%")
                                    {
                                        Console.WriteLine($"{x} % {y} = {d = x % y}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Неправильно введена операция, повторите попытку");
                                        CalculationOperation(x, y);
                                    }
                                }
                                
                            }
                        }
                    }
                }
            }
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                Console.WriteLine("Введите первое число");
                long a = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Введите второе число");
                long b = Convert.ToInt64(Console.ReadLine());
                CalculationOperation( a , b );
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка ввода, проверьте корректность введененых значений");
                Hardmode();
            }
        }
    }
}
