using System;

namespace ClassWork6
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new double[7];
            int counter = 0;
            double sum = 0;

            while ( counter < numbers.Length)
            {
                try
                {
                    Console.WriteLine($"Type in a number {counter+1}");
                    sum += double.Parse(Console.ReadLine());
                    Console.WriteLine($"Sum of numbers is {sum}");
                    counter++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Not a number!");
                    continue;
                }
            }
            Console.WriteLine($"Sum of all numbers is {sum}");
            //while (!string.Equals(input,"exit", StringComparison.OrdinalIgnoreCase));
            Console.ReadKey();
        }
    }
}
