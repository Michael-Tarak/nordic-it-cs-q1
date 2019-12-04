using CityApp.Models;

namespace CityApp.ViewModels
{
    public class DetailCityViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Descryption { get; set; }
        public int Population { get; set; }
        public DetailCityViewModel(City city)
        {
            Id = city.Id.ToString("N");
            Name = city.Name;
            Descryption = city.Descryption;
            Population = city.Population;
                
        }
        public DetailCityViewModel()
        {

        }
    }
}
