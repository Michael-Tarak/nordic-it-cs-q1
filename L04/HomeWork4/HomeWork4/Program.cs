using System;

namespace HomeWork4
{
    [Flags] enum Containers {Один_литр = 0x1,Пять_литров = 0x2, Двадцать_литров = 0x4 };
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Какой объем сока(в литрах) требуется упаковать?");
            double volumeLitras;
            while(true)
            {
                if (double.TryParse(Console.ReadLine(), out volumeLitras) && volumeLitras >= 0)
                    break;

            }
            if (volumeLitras == 0)
                Console.WriteLine("Контейнеры не нужны.");
            else
            {
                Containers containersFlags = 0;
                short[] containersCounter = new short[3];
                while (volumeLitras > 0)
                {
                    if (volumeLitras >= 20)
                    {
                        containersFlags |= Containers.Двадцать_литров;
                        volumeLitras -= 20;
                        containersCounter[2]++;
                    }
                    else if (volumeLitras >= 5)
                    {
                        containersFlags |= Containers.Пять_литров;
                        volumeLitras -= 5;
                        containersCounter[1]++;

                    }
                    else
                    {
                        containersFlags |= Containers.Один_литр;
                        volumeLitras -= 1;
                        containersCounter[0]++;
                    }
                }
                byte j = 0;
                Console.WriteLine("Вам потребуются следующие контейнеры:");
                foreach (Containers i in Enum.GetValues(typeof(Containers)))
                {
                    if ((containersFlags & i) == i)
                        Console.WriteLine($"{i}: {containersCounter[j]} шт.");
                    j++;
                }
            }
        }
    }
}
