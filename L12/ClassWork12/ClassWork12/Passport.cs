using System;
namespace ClassWork12
{
    class Passport : BaseDocument
    {
        public Passport(string number, DateTimeOffset issueDate, string country, string personName)
            :base ("Passport", number, issueDate)
        {
            Country = country;
            PersonName = personName;
        }
        public string Country { get; set; }
        public string PersonName { get; set; }
        public override string Description =>
            $"{base.Description}, Country: {Country}, Person Name: {PersonName}";
    }
}
