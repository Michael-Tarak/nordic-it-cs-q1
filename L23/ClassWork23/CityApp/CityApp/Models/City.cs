using System;

namespace CityApp.Models
{
    public class City
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Descryption { get; set; }
        public int Population { get; set; }

        public City(string name,
            string descryption,
            int population)
        {
            Id = Guid.NewGuid();
            Name = name;
            Descryption = descryption;
            Population = population;
        }

	}
}
