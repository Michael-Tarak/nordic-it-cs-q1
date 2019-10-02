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
            Console.WriteLine($"Введите тип фигуры({(int)Figures.Circle} - {Figures.Circle}," +
                $" {(int)Figures.Triangle} - {Figures.Triangle}," +
                $" {(int)Figures.Rectangle} - {Figures.Rectangle} ):");
            try
            {
                double squareOfFigure = default;
                double perimeterOfFigure = default;
                short figureInput = short.Parse(Console.ReadLine());
                switch(figureInput)
                {
                    case 1:
                        Console.Write("Введите значение диаметра: ");
                        double circleDiameter = double.Parse(Console.ReadLine());
                        if (circleDiameter <= 0)
                            throw new ArgumentException();
                        squareOfFigure = Math.PI * Math.Pow(circleDiameter/2d, 2);
                        perimeterOfFigure = Math.PI * circleDiameter;
                        break;
                    case 2:
                        Console.Write("Введите значение стороны треугольника: ");
                        double sideOfTriangle = double.Parse(Console.ReadLine());
                        if (sideOfTriangle <= 0)
                            throw new ArgumentException();
                        squareOfFigure = (Math.Pow(sideOfTriangle, 2) * Math.Pow(3d, 2)) / 4d;
                        perimeterOfFigure = sideOfTriangle * 3d;
                        break;
                    case 3:
                        Console.Write("Введите значение длины прямоугольника: ");
                        double lengthOfRectangle = double.Parse(Console.ReadLine());
                        Console.Write("Введите значение ширины прямоугольника: ");
                        double widthOfRectangle = double.Parse(Console.ReadLine());
                        if (widthOfRectangle <= 0 || lengthOfRectangle <= 0)
                            throw new ArgumentException();
                        squareOfFigure = lengthOfRectangle * widthOfRectangle;
                        perimeterOfFigure = (lengthOfRectangle + widthOfRectangle) * 2;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine($"Площадь поверхности фигуры: {squareOfFigure}");
                Console.WriteLine($"Периметр фигуры: {perimeterOfFigure}");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Введен номер несуществующей фигуры.");
                ChoiceOfFigure();
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Заданное значение параметра невозможно для данной фигуры.");
                ChoiceOfFigure();
            }
            catch (FormatException)
            {
                Console.WriteLine("Некорректный ввод числовых данных.");
                ChoiceOfFigure();
            }
            catch(OverflowException)
            {
                Console.WriteLine("Введено запредельное число.");
                ChoiceOfFigure();
            }
        }
    }
}
