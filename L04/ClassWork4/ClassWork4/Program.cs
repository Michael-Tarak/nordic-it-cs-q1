using System;

namespace ClassWork4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            double a;
            double h;
            Console.WriteLine("Введите значение стороны основания");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out a))
                    break;
            }
            Console.WriteLine("Введите значение высоты");
            while(true)
            {
                if (double.TryParse(Console.ReadLine(), out h))
                    break;
            }
            Console.WriteLine($"Площадь боковой стороны: {3.0 * a * h}");
            Console.WriteLine($"Полная площадь фигуры: {(3.0/2.0)*a*(a*Math.Cbrt(3.0)+2.0*h)}");
            Console.WriteLine($"Объем фигуры: {(Math.Pow(a,2)/2.0)*h*Math.Cbrt(3.0)}");
        }
    }
}
