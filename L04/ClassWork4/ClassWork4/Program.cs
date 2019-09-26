using System;

namespace ClassWork4
{
    //enum Season : int
    //{
    //    Зима = 3,
    //    Весна = 6,
    //    Лето = 9,
    //    Осень = 12
    //};
    [Flags] enum Colors:short {Черный  = 1, Синий = 2, Циан = 4, Серый = 8, Зеленый = 16, Пурпурный = 32, Красный = 64, Белый = 128, Желтый = 256};

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("Список цветов:");
            foreach(short i in Enum.GetValues(typeof(Colors)))
            {
                Console.WriteLine($"{(Colors)i} - {i}");
            }
            Colors favoriteColors = 0;
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Выберите {i+1}-й цвет: ");
                favoriteColors = favoriteColors | (Colors)Int16.Parse(Console.ReadLine());
            }
            Colors notFavoriteColors = (Colors)(~(short)favoriteColors^65024);
            Console.WriteLine($"Избранные вами цвета: {favoriteColors}\nОставшиеся цвета: {notFavoriteColors}");
            //Console.WriteLine(Convert.ToString((short)favoriteColors, toBase: 2));
            //Console.WriteLine(Convert.ToString((short)notFavoriteColors,toBase: 2));
        }
           
    }
}
