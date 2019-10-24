using System;

namespace ClassWork11
{
    class Program
    {
        static void Main(string[] args)
        {
            var pet1 = new Pet()
            {
                Name = "Alex",
                Kind = "Lion",
                Sex = 'M',
                DateOfBirth = new DateTime(2018,6,20)
            };
            var pet2 = new Pet()
            {
                Name = "Morty",
                Kind = "Zebra",
                Sex = 'M',
                DateOfBirth = new DateTime(2000,5,16)
            };
            pet1.Display(true);
            pet2.Display(false);
            Console.ReadKey();
        }
    }
}
