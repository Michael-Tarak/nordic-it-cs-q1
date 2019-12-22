using L23_C02_asp_net_core_app_final.Storage;

namespace L23_C02_asp_net_core_app_final.ViewModels
{
	public class CityViewModel
	{
		public string Id { get; set; }

		public string Title { get; set; }

		public CityViewModel(City city)
		{
			Id = city.Id.ToString("N");
			Title = city.Name;
		}

		public CityViewModel()
		{
		}
	}
}
