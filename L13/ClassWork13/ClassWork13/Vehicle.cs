namespace ClassWork13
{
    abstract class Vehicle
    {
        public int MaxHeight { get; set; }
        public int CurrentHeight { get; set; }
        public abstract void TakeUpper(int delta);
        public abstract void TakeLower(int delta);

    }
}
