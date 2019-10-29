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
        public override void TakeUpper(int delta)
        {
            try
            {
                if (delta <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                CurrentHeight += delta;
                if (CurrentHeight > MaxHeight)
                {
                    CurrentHeight = MaxHeight;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Неверное значение!");
            }
        }
        public override void TakeLower(int delta)
        {
            try
            {
                if (delta <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                CurrentHeight -= delta;
                if (CurrentHeight < 0)
                {
                    throw new InvalidOperationException();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Неверное значение!");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Crash!");
            }
        }
        public void WriteAllProperties()
        {
            Console.WriteLine($"EnginesCount: {EnginesCount}\nCurrentHeight: {CurrentHeight}\nMaxHeight: {MaxHeight}");
        }
    }
}
