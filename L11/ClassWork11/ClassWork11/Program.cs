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
            Console.WriteLine(pet1.Description);
            var pet2 = new Pet()
            {
                Name = "Morty",
                Kind = "Zebra",
                Sex = 'M',
                DateOfBirth = new DateTime(2000,5,16)
            };
            Console.WriteLine(pet2.Description);
            pet1.Display();
            pet2.Display();
            Console.ReadKey();
        }
    }
}
