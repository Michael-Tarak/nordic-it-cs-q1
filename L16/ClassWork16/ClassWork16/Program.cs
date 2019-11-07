using System;

namespace ClassWork16
{
    public sealed class Circle
    {
        private double _radius;
        public Circle(double radius)
        {
            _radius = radius;
        }
        public double Calculate (Func<double, double> operation)
        {
            return operation(_radius);
        }
    }
    class Program
    {
        delegate double Calculation(double radius);
        static void Main(string[] args)
        {
            Circle circle1 = new Circle(1.5);
            Calculation square = (x) => Math.PI * x * x;
            Calculation perimeter = (x) => 2 * x * Math.PI;
            Console.WriteLine(circle1.Calculate(square));
            Console.WriteLine(circle1.Calculate(perimeter));
        }
        
    }
}
