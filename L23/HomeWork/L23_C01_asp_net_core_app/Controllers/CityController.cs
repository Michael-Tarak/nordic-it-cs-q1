using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using L23_C01_asp_net_core_app.Storage;
using L23_C01_asp_net_core_app.ViewModels;

namespace L23_C01_asp_net_core_app.Controllers
{
	[Route("/api/city")]
	public class CityController : Controller
	{
		[HttpGet(Name = nameof(GetCities))]
		public IActionResult GetCities()
		{
			var models = CityStorage.Instance
				.GetAll()
				.Select(_ => new CityViewModel(_))
				.ToList();

			return Ok(models);
		}

		[HttpGet("{id}", Name = nameof(GetCity))]
		public IActionResult GetCity(Guid id)
		{
			var city = CityStorage.Instance.GetById(id);

			if (city == null)
			{
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
				return BadRequest();
			}

			var duplicate = CityStorage.Instance.FindByName(model.Name);
			if (duplicate != null)
			{
				return Conflict();
			}

			var city = new City
			{
				Id = Guid.NewGuid(),
				Name = model.Name,
				Description = model.Description,
				Population = model.Population
			};

			CityStorage.Instance.Create(city);

			return CreatedAtRoute("GetCity", new {Id = city.Id.ToString("N")}, city);
		}
	}
}