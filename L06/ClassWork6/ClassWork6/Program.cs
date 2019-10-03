using System;

namespace ClassWork6
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            do
            {
                try
                {
                    Console.WriteLine("Type in your string, to leave, type exit");
                    input = Console.ReadLine();
                    if (input.Length > 15)
                        throw new OverflowException();
                    Console.WriteLine("Entered string length is {0}", input.Length);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Too long string. Try another:");
                    continue;
                }
            } while (!string.Equals(input,"exit", StringComparison.OrdinalIgnoreCase));
            Console.ReadKey();
        }
    }
}
