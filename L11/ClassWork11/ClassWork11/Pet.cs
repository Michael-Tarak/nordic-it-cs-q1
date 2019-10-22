using System;

namespace ClassWork11
{
    class Pet
    {
        public string Kind;
        public string Name;
        public char Sex;
        public DateTime DateOfBirth;
        public byte Age
        {
            get 
            {
                var difference = DateTime.Now - DateOfBirth;
                return (byte)Math.Floor(difference.TotalDays / 365);
            }
        }

        public string Description
        {
            get { return $"{Name} is a {Kind} ({Sex}) of {Age} years old"; }
        }
        public void Display()
        {
            Console.WriteLine($"{Name} is a {Kind} ({Sex}) of {Age} years old");
        }
    }
}
