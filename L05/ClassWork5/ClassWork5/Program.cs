using System;

namespace ClassWork5
{
    class Program
    {
        static void Main(string[] args)
        {
            double output;
            while(true)
            {
                if(double.TryParse(Console.ReadLine(), out output))
                {
                    break;
                }
            }
            if (output > 100)
            {
                Console.WriteLine("Input is more than 100");
            }
            else
            {
                Console.WriteLine("Input is less or equal 100");
            }
        }
    }
}
