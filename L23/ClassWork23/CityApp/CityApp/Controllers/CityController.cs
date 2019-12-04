using CityApp.Models;
using CityApp.Services;
using CityApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CityApp.Controllers
{

    /// <summary>
    ///  Контроллер, определяет логику по управлению данными городов
    /// </summary>
    public class CityController : Controller
	{
        // GET /cities
        // GET /api/city/list
        [HttpGet("cities")]
        [HttpGet("api/city/list")]
        public IActionResult List()
        {
            var cities = CityStorage.Instance
                .GetAll()
                .Select((City city) => new CityViewModel(city))
                .OrderBy((CityViewModel viewModel) => viewModel.Name)
                .ToArray();
            return Ok(cities);
        }

        //GET cities/id
        //GET api/city/id
        [HttpGet("cities/{id}", Name = "Get")]
        [HttpGet("api/city/{id}", Name = "ApiGet")]
        public IActionResult Get(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest();
            }
            var city = CityStorage.Instance.GetById(id);
            if(city == null)
            {
                return NotFound();
            }
            return Ok(new DetailCityViewModel(city));
        }

        // POST /cities
        // POST /api/city/post
        [HttpPost("cities")]
		[HttpPost("api/city")]
		public IActionResult Create([FromBody] CreateCityViewModel city)
		{
            if(city == null)
            {
                return BadRequest();
            }
            var model = new City(
                city.Name,
                city.Descryption,
                city.Population);
            CityStorage.Instance.Create(model);
            return CreatedAtAction("Get", model);
        }
    }
}
