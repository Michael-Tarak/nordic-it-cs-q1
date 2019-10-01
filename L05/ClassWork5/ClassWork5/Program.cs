using System;

namespace ClassWork5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            byte output;
            while(true)
            {
                if(byte.TryParse(Console.ReadLine(), out output))
                {
                    break;
                }
            }
            int lastDigit = output % 10;
            switch (lastDigit)
            {
                case 1:
                    Console.WriteLine($"{output} год");
                    break;
                case 2:
                case 3:
                case 4:
                    Console.WriteLine($"{output} года");
                    break;
                default:
                    Console.WriteLine($"{output} лет");
                    break;
            }

        }
    }
}
