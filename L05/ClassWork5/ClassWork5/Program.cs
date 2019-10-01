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
            var outputNew = (output > 100 ? "Input is more than 100" : "Input is less or equal 100");
            Console.WriteLine(outputNew);
        }
    }
}
