using System;
namespace ClassWork12
{
    class BaseDocument
    {
        public BaseDocument(string title, string number, DateTimeOffset issueDate)
        {
            Title = title;
            Number = number;
            IssueDate = issueDate;
        }
        public string Title { get; set; } 
        public string Number { get; set; }
        public DateTimeOffset IssueDate { get; set; }
        public virtual string Description =>
            $"Title: {Title}, Number: {Number}, Issue Date: {IssueDate}";
        public void WriteToConsole()
        {
            Console.WriteLine(Description);
        }
    }
}
