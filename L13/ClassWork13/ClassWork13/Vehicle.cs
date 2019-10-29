using System;
namespace ClassWork13
{
     abstract class  Vehicle
     {
        public int MaxHeight { get; set; }
        public int CurrentHeight { get; set; }
        public void TakeUpper(int delta)
        {
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

        }
        public  void TakeLower(int delta)
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
     }
}
