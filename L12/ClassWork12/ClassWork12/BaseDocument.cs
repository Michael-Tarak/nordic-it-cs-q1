using System;
namespace ClassWork12
{
    class BaseDocument
    {
        public string Title { get; set; } 
        public string Number { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public string Description =>
            $"Title: {Title}, Number: {Number}, Issue Date: {IssueDate}";
        public void WriteToConsole()
        {
            Console.WriteLine(Description);
        }
    }
    class Passport : BaseDocument
    {
        public string Country { get; set; }
        public string PersonName { get; set; }
        public new string Description =>
            $"{base.Description}, Country: {Country}, Person Name: {PersonName}";
        public new void WriteToConsole()
        {
            Console.WriteLine(Description);
        }

    }
}
