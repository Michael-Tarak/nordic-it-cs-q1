using System;

namespace ClassWork13
{
    class Program
    {
        static void Main(string[] args)
        {
            var heli = new Helicopter(2000, 4);
            var biplane = new Plane(3500, 2);
            while(true)
            {
                Console.WriteLine("Choose vehicle");
                var vehicle = Console.ReadLine();
                int input;
                switch (vehicle)
                {
                    case "heli":
                        heli.WriteAllProperties();
                        Console.WriteLine("Change height: ");
                        input = int.Parse(Console.ReadLine());
                        if (input < 0)
                        {
                            heli.TakeLower(input);
                        }
                        else
                        {
                            heli.TakeUpper(input);
                        }
                        break;
                    case "plane":
                        biplane.WriteAllProperties();
                        Console.WriteLine("Change height: ");
                        input = int.Parse(Console.ReadLine());
                        if (input < 0)
                        {
                            biplane.TakeLower(input);
                        }
                        else
                        {
                            biplane.TakeUpper(input);
                        }
                        break;
                    default:
                        Console.WriteLine("Wrong");
                        break;
                }
            }
        }
    }
}
