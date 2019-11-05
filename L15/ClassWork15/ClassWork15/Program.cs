using System;

namespace ClassWork15
{
    public sealed class Circle
    {
        private double _radius;
        public Circle(double radius)
        {
            _radius = radius;
        }
        public double Calculate(Func<double,double> operation)
        {
            return operation(_radius);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle1 = new Circle(1.5);
            Console.WriteLine($"Perimeter is: {circle1.Calculate(PerimeterCalculator)}");
            Console.WriteLine($"Square is: { circle1.Calculate(SquareCalculator)}");
        }
        public static double PerimeterCalculator(double radius)
        {
            return 2*radius*Math.PI;
        }
        public static double SquareCalculator(double radius)
        {
            return Math.PI*radius*radius;
        }
    }
}
