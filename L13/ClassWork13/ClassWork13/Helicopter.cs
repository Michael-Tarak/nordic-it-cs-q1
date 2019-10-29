using System;
namespace ClassWork13
{
    class Helicopter : Vehicle
    {
        public byte BladesCount { get; set; }
        public Helicopter(int maxHeight, byte bladesCount)
        {
            MaxHeight = maxHeight;
            BladesCount = bladesCount;
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
            Console.WriteLine($"BladesCount: {BladesCount}\nCurrentHeight: {CurrentHeight}\nMaxHeight: {MaxHeight}");
        }
    }
}
