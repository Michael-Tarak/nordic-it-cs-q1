using CityApp.Controllers;
using CityApp.Models;
using System;

namespace CityApp.ViewModels
{
    public class CityViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public CityViewModel(City city)
        {
            Id = city.Id.ToString("N");
            Name = city.Name;
        }
        public CityViewModel()
        {

        }
    }
}
