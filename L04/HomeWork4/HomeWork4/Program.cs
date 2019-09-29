using System;

namespace HomeWork4
{
    [Flags] enum Containers
    {
        One_Litre = 0x1,
        Five_Litres = 0x2,
        Twenty_litres = 0x4
    };
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
                containersCounter[2] = Convert.ToInt16(Math.Floor(volumeLitras / 20));
                if (containersCounter[2] != 0)
                {
                    containersFlags |= Containers.Twenty_litres;
                    volumeLitras -= Convert.ToDouble(containersCounter[2] * 20);
                }
                containersCounter[1] = Convert.ToInt16(Math.Floor(volumeLitras / 5));
                if(containersCounter[1] != 0)
                {
                    containersFlags |= Containers.Five_Litres;
                    volumeLitras -= Convert.ToDouble(containersCounter[1] * 5);
                }
                containersCounter[0] = Convert.ToInt16(Math.Ceiling(volumeLitras));
                if(containersCounter[0] != 0)
                    containersFlags |= Containers.One_Litre;
                var containersCycle = (Containers[])Enum.GetValues(typeof(Containers));
                Console.WriteLine("Вам потребуются следующие контейнеры:");
                for (int i = 0; i < containersCycle.Length; i++)
                {
                    if ((containersFlags & containersCycle[i]) == containersCycle[i])
                        Console.WriteLine($"{containersCycle[i]}: {containersCounter[i]} шт.");
                }
            }
        }
    }
}
