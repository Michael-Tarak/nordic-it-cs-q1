using System;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            string[] names = new string[3];
            for(int i = 0; i < names.Length; i++)
            {
                Console.Write($"Введите {i + 1}-е имя: ");
                names[i] = Console.ReadLine();
            }
            byte[] ages = new byte[3];
            for (int i = 0; i <ages.Length; i++)
            {
                while(true)
                {
                    Console.Write($"Введите возраст {i + 1}-го человека: ");
                    if (byte.TryParse(Console.ReadLine(), out ages[i]))
                    {
                        if (ages[i] > 0)
                            break;
                    }
                    Console.WriteLine("Введен некорректный возраст, повторите попытку.");
                }
            }
            Console.WriteLine("Список персон:");
            for(int i = 0; i < names.Length && i < ages.Length; i++)
            {
                Console.WriteLine($"Имя: {names[i]}; возраст через 4 года: {ages[i]+4}.");
            }
        }
    }
}
