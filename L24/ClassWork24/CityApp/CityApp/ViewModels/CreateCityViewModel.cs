using System;
using CityApp.Models;

namespace CityApp.ViewModels
{
    public class CreateCityViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Polulation { get; set; }
    }

    public class CityViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public CityViewModel()
        {
        }

        public CityViewModel(City city)
        {
            Id = city.Id.ToString("N");
            Name = city.Name;
        }
    }

    public class DetailCityViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Polulation { get; set; }

        public DetailCityViewModel()
        {
        }

        public DetailCityViewModel(City city)
        {
            Id = city.Id.ToString("N");
            Name = city.Name;
            Description = city.Description;
            Polulation = city.Population;
        }
    }
}
