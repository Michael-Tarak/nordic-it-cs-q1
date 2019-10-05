using System;

namespace HomeWork5
{
    class Program
    {
        [Flags]
        enum Figures
        {
            Circle = 1,
            Triangle,
            Rectangle
        };
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            ChoiceOfFigure();
        }
        static void ChoiceOfFigure()
        {
            bool exitBool = false;
            while(!exitBool)
            {
                Console.WriteLine($"Введите тип фигуры({(int)Figures.Circle} - {Figures.Circle}," +
                    $" {(int)Figures.Triangle} - {Figures.Triangle}," +
                    $" {(int)Figures.Rectangle} - {Figures.Rectangle} ), для выхода введите 0:");
                try
                {
                    double squareOfFigure = default;
                    double perimeterOfFigure = default;
                    Figures figureInput = (Figures)Enum.Parse(typeof(Figures), Console.ReadLine());
                    switch (figureInput)
                    {
                        case 0:
                            exitBool = true;
                            break;
                        case Figures.Circle:
                            double circleDiameter;
                            while (true)
                            {
                                Console.Write("Введите значение диаметра: ");
                                if (double.TryParse(Console.ReadLine(), out circleDiameter) && circleDiameter > 0)
                                {
                                    break;
                                }
                                Console.WriteLine("Неподходящее значение!");
                            }
                            squareOfFigure = Math.PI * Math.Pow(circleDiameter / 2d, 2);
                            perimeterOfFigure = Math.PI * circleDiameter;
                            break;
                        case Figures.Triangle:
                            double sideOfTriangle;
                            while (true)
                            {
                                Console.Write("Введите значение стороны треугольника: ");
                                if (double.TryParse(Console.ReadLine(), out sideOfTriangle) && sideOfTriangle > 0)
                                {
                                    break;
                                }
                                Console.WriteLine("Неподходящее значение!");
                            }
                            squareOfFigure = (Math.Pow(sideOfTriangle, 2) * Math.Pow(3d, 2)) / 4d;
                            perimeterOfFigure = sideOfTriangle * 3d;
                            break;
                        case Figures.Rectangle:
                            double lengthOfRectangle;
                            double widthOfRectangle;
                            while (true)
                            {
                                Console.Write("Введите значение длины прямоугольника: ");
                                if (double.TryParse(Console.ReadLine(), out lengthOfRectangle ) && lengthOfRectangle > 0)
                                {
                                    Console.Write("Введите значение ширины прямоугольника: ");
                                    if (double.TryParse(Console.ReadLine(), out widthOfRectangle) && widthOfRectangle > 0)
                                    {
                                        break;
                                    }
                                }
                                Console.WriteLine("Неподходящее значение!");
                            }
                            squareOfFigure = lengthOfRectangle * widthOfRectangle;
                            perimeterOfFigure = (lengthOfRectangle + widthOfRectangle) * 2;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    if(squareOfFigure != 0 && perimeterOfFigure != 0)
                    {
                        Console.WriteLine($"Площадь поверхности фигуры: {squareOfFigure}");
                        Console.WriteLine($"Периметр фигуры: {perimeterOfFigure}");

                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Введен номер несуществующей фигуры.");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Заданное значение параметра невозможно для данной фигуры.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Некорректный ввод числовых данных.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Введено запредельное число.");
                }
            }
        }
    }
}
