using System;

namespace ClassWork6
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            do
            {
                Console.InputEncoding = System.Text.Encoding.Unicode;
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.WriteLine("Введите exit для выхода");
                 input = Console.ReadLine();
            }
            while (input != "exit".ToLower());
        }
    }
}
