using System;
using System.Collections.Generic;
using System.Linq;

namespace L23_C01_asp_net_core_app.Storage
{
	/// <summary>
	/// Cities in memory storage
	/// </summary>
	public class CityStorage
	{
		// Singleton implementation
		// private static field and public static lazy evaluted property

		private static CityStorage _instance;
		public static CityStorage Instance =>
			_instance ?? (_instance = new CityStorage());

		// underlying collection of cities
		private readonly List<City> _cities;

		private CityStorage()
		{
			_cities = new List<City>
			{
				new City
				{
					Id = Guid.NewGuid(),
					Name = "Москва",
					Population = 16_000_000
				},
				new City
				{
					Id = Guid.NewGuid(),
					Name = "Санкт Петербург",
					Population = 5_000_000
				}
			};
		}

		/// <summary>
		/// Returns all cities ordered by name
		/// </summary>
		public City[] GetAll()
		{
			return _cities
				.OrderBy(_ => _.Name)
				.ToArray();
		}

		/// <summary>
		/// Returns single city by specified identity or returns null
		/// </summary>
		public City GetById(Guid id)
		{
			return _cities.FirstOrDefault(_ => _.Id == id);
		}

		/// <summary>
		/// Finds single city by specified name or returns null
		/// </summary>
		public City FindByName(string name)
		{
			return _cities.FirstOrDefault(_ => string.Equals(_.Name, name?.Trim(), StringComparison.OrdinalIgnoreCase));
		}

		/// <summary>
		/// Adds new city element 
		/// </summary>
		public void Create(City city)
		{
			_cities.Add(city);
		}
	}
}
