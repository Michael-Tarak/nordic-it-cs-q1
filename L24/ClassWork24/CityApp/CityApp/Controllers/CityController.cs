using CityApp.Models;
using CityApp.Services;
using CityApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace CityApp.Controllers
{
    /// <summary>
    ///  Контроллер, определяет логику по управлению данными городов
    /// </summary>
    public class CityController : Controller
    {
        private ILogger _logger;
        private CityStorage _storage;

        public CityController(ILogger<CityController> logger, CityStorage storage)
        {
            _logger = logger;
            _storage = storage;
        }
        // GET /cities
        // GET /api/city/list
        [HttpGet("cities")]
        [HttpGet("api/city/list")]
        public IActionResult List()
        {
            var cities = _storage
                .GetAll() // City[] -> IEnumerable<City>
                .Select((City city) => new CityViewModel(city))
                .OrderBy((CityViewModel viewModel) => viewModel.Name)
                .ToArray();

            return Ok(cities);
        }

        // GET /cities/id
        // GET /api/city/id
        [HttpGet("cities/{id}", Name = "Get")]
        [HttpGet("api/city/{id}", Name = "ApiGet")]
        public IActionResult Get(Guid id)
        {
            if (id == Guid.Empty)
            {
                _logger.LogWarning("Invalid id specified");
                return BadRequest();
            }

            var city = _storage.GetById(id);
            if (city == null)
            {
                _logger.LogWarning("City with id {0} is not found", id);
                return NotFound();
            }

            return Ok(new DetailCityViewModel(city));
        }

        // POST /cities
        // POST /api/city
        [HttpPost("cities")]
        [HttpPost("api/city")]
        public IActionResult Create([FromBody] CreateCityViewModel city)
        {
            if (city == null)
            {
                return BadRequest();
            }

            var model = new City(
                city.Name,
                city.Description,
                city.Polulation);

            _storage.Create(model);

            return CreatedAtAction("Get", model);
        }
    }
}
