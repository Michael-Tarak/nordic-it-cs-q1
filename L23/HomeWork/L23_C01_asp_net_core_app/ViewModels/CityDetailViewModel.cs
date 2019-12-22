using L23_C01_asp_net_core_app.Storage;

namespace L23_C01_asp_net_core_app.ViewModels
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
