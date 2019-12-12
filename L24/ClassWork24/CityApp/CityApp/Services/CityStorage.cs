using System;
using System.Linq;
using System.Collections.Generic;
using CityApp.Models;

namespace CityApp.Services
{
    /// <summary>
    /// Хранилище городов
    /// </summary>
    public class CityStorage
    {

        private readonly List<City> _cities;

        public CityStorage()
        {
            _cities = new List<City>
            {
                new City("Москва", "Столица России", 16_000_000),
                new City("Санкт Петербург", "Северная столица России", 5_000_000)
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
