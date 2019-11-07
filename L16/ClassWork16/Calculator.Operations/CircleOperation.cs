using System;
using Calculator.Figures;

namespace Calculator.Operations
{
    class CircleCalculation
    {
        public CircleCalculation(Circle circle)
        {
            Console.WriteLine(circle.Calculate(PerimeterCalculator));
            Console.WriteLine(circle.Calculate(SquareCalculator));
        }
        public static double PerimeterCalculator(double radius)
        {
            return 2 * Math.PI * radius;
        }
        public static double SquareCalculator(double radius)
        {
            return Math.PI * radius * radius;
        }
    }
}
