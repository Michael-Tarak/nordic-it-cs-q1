using System;
namespace ClassWork13
{
    class Plane : Vehicle
    {
        byte EnginesCount { get; set; }
        public Plane(int maxHeight, byte enginesCount)
        {
            MaxHeight = maxHeight;
            EnginesCount = enginesCount;
            CurrentHeight = 0;
        }
        public void WriteAllProperties()
        {
            Console.WriteLine($"EnginesCount: {EnginesCount}\nCurrentHeight: {CurrentHeight}\nMaxHeight: {MaxHeight}");
        }
    }
}
