using System;
using Calculator.Figures;
using Calculator.Operations;

namespace ClassWork16
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle1 = new Circle(10);
            var calc = new CircleCalculation(circle1);
        }
        
    }
}
