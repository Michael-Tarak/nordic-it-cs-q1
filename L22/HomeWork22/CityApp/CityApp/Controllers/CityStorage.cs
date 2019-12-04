using System;
using System.Collections.Generic;

namespace CityApp.Controllers
{
    /// <summary>
    /// Хранилище городов
    /// </summary>
    public class CityStorage
	{

		private static CityStorage _instance;

		public static CityStorage Instance =>
			_instance ?? (_instance = new CityStorage());

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
		/// Метод возвращает список всех городов
		/// </summary>
		public City[] GetAll()
		{
			return _cities.ToArray();
		}

        /// <summary>
        /// Заменяет существующий город в коллекции
        /// </summary>
        public void Update(City city)
        {
            _cities.Remove(_cities.Find(x => x.Id == city.Id));
            _cities.Add(city);
        }

        /// <summary>
        /// Метод добавляет город в коллекцию 
        /// </summary>
        public void Create(City city)
		{
			_cities.Add(city);
		}

        /// <summary>
        /// Метод удаляет город из коллекции
        /// </summary>
        public void Delete(City city)
        {
            _cities.Remove(_cities.Find(x => x.Id == city.Id));
        }
	}
}
