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
        public void WriteAllProperties()
        {
            Console.WriteLine($"{nameof(BladesCount)}: {BladesCount}\n{nameof(CurrentHeight)}: {CurrentHeight}\n{nameof(MaxHeight)}: {MaxHeight}");
        }
    }
}
