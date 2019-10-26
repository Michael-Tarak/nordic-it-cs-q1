using System;

namespace ClassWork12
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new BaseDocument("License", "42", DateTimeOffset.Now);
            var passport = new Passport("1337", DateTimeOffset.Now,"Russia", "Ivan");
            doc.WriteToConsole();
            passport.WriteToConsole();
            Console.ReadKey();
        }
    }
}
