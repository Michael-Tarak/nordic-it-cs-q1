using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using L23_C02_asp_net_core_app_final.Storage;
using L23_C02_asp_net_core_app_final.ViewModels;

namespace L23_C02_asp_net_core_app_final.Controllers
{
	[Route("/api/city")]
	public class CityController : Controller
	{
		private readonly ILogger _logger;
		private readonly ICityStorage _storage;

		public CityController(ILogger<CityController> logger, ICityStorage storage)
		{
			_logger = logger;
			_storage = storage;
		}

		[HttpGet(Name = nameof(GetCities))]
		public IActionResult GetCities()
		{
			var models = _storage
				.GetAll()
				.Select(_ => new CityViewModel(_))
				.ToList();

			return Ok(models);
		}

		[HttpGet("{id}", Name = nameof(GetCity))]
		public IActionResult GetCity(Guid id)
		{
			var city = _storage.GetById(id);
			if (city == null)
			{
				_logger.LogWarning("Invalid id detected");
				return NotFound();
			}

			var model = new CityDetailViewModel(city);
			return Ok(model);
		}

		[HttpPost(Name = nameof(CreateCity))]
		public IActionResult CreateCity([FromBody] CityCreateViewModel model)
		{
			if (model == null)
			{
				_logger.LogWarning("Empty payload detected");
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				_logger.LogInformation("Bad payload detected");
				return BadRequest(ModelState);
			}

			var duplicate = _storage.FindByName(model.Name);
			if (duplicate != null)
			{
				_logger.LogWarning("Creation conflict detected");
				return Conflict();
			}


			var city = new City
			{
				Id = Guid.NewGuid(),
				Name = model.Name,
				Description = model.Description,
				Population = model.Population
			};

			_storage.Create(city);

			return CreatedAtRoute("GetCity", new { Id = city.Id.ToString("N") }, city);
		}

        [HttpPut("{id}", Name = nameof(UpdateCity))]
        public IActionResult UpdateCity(Guid id, [FromBody] CityUpdateViewModel model)
        {
            if (model == null)
            {
                _logger.LogWarning("Empty payload detected");
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Bad payload detected");
                return BadRequest(ModelState);
            }

            if (_storage.GetById(id) == default)
            {
                _logger.LogWarning("City does not exist");
                return NotFound();
            }

            var city = new City
            {
                Id = id,
                Name = model.Name,
                Description = model.Description,
                Population = model.Population
            };

            _storage.Update(city);

            return Ok();
        }

        [HttpDelete("{id}", Name = nameof(DeleteCity))]
        public IActionResult DeleteCity(Guid id)
        {
            var city = _storage.GetById(id);
            if (city == null)
            {
                _logger.LogWarning("Invalid id detected");
                return NotFound();
            }
            _storage.Delete(id);
            return Ok();
        }
    }
}