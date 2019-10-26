using System;

namespace ClassWork12
{
    class Program
    {
        static void Main(string[] args)
        {
            var documents = new BaseDocument [3];
            documents[0] = new BaseDocument("Driver License", "42", DateTimeOffset.Parse("19-01-2000"));
            documents[1] = new Passport("1992", DateTimeOffset.Parse("20-06-2013 09:08:00"), "Belarus", "Vladimir");
            documents[2] = new BaseDocument("Warrant", "1984", DateTimeOffset.Parse("01-01-1984"));
            foreach(var document in documents)
            {
                if(document is Passport)
                {
                    var doc = (Passport)document;
                    doc.ChangeIssueDate(DateTimeOffset.Now);
                    document.IssueDate = doc.IssueDate;
                }
                document.WriteToConsole();
            }
            Console.ReadKey();
        }
    }
}
