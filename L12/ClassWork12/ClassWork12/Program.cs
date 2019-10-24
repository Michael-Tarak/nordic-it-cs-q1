using System;

namespace ClassWork12
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new BaseDocument()
            {
                Title = "Title",
                Number = "1337",
                IssueDate = DateTime.Now
            };
            var passport = new Passport()
            {
                Title = "title",
                Number = "42",
                IssueDate = DateTime.Now,
                Country = "Belgium",
                PersonName = "Ivan"
            };
            doc.WrieToConsole();
            passport.WrieToConsole();
        }
    }
}
