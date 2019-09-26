using System;

namespace ClassWork4
{
    enum Season : int
    {
        Winter = 3,
        Spring = 6,
        Summer = 9,
        Autumn = 12
    };
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Введите номер сезона");
            int seasonNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{(Season)seasonNumber}");
        }
           
    }
}
