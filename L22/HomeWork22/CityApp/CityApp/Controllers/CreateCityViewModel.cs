using System;

namespace CityApp.Controllers
{
    public class CreateCityViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Descryption { get; set; }
        public int Population { get; set; }
    }
}
