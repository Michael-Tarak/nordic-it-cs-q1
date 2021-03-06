﻿using CityApp.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CityApp.Services
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
                new City("Москва", "Столица России",16_000_000),
				new City("Санкт Петербург", "Северная столица России",5_000_000)
			};
		}

		/// <summary>
		/// Метод возвращает список всех городов
		/// </summary>
		public City[] GetAll()
		{
			return _cities.ToArray();
		}

        public City GetById(Guid id)
        {
            return _cities.FirstOrDefault(city => city.Id == id);
        }

        /// <summary>
        /// Метод добавляет город в коллекцию 
        /// </summary>
        public void Create(City city)
		{
			_cities.Add(city);
		}
	}
}
