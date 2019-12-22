using L23_C02_asp_net_core_app_final.Storage;

namespace L23_C02_asp_net_core_app_final.ViewModels
{
	public class CityDetailViewModel
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public int Population { get; set; }

		public CityDetailViewModel(City city)
		{
			Id = city.Id.ToString("N");
			Name = city.Name;
			Description = city.Description;
			Population = city.Population;
		}

		public CityDetailViewModel()
		{
		}
	}
}
