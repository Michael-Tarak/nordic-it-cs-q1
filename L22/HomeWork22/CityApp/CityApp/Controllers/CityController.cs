using Microsoft.AspNetCore.Mvc;
using System;

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
        [HttpGet("api/city")]
        public IActionResult List() =>
            Json(CityStorage.Instance.GetAll());

        // POST /cities
        // POST /api/city
        [HttpPost("cities")]
		[HttpPost("api/city")]
		public IActionResult Create([FromBody] CreateCityViewModel model)
		{
			CityStorage.Instance.Create(
                new City
                {
                    Id = model.Id,
                    Name = model.Name,
                    Population=model.Population,
                    Descryption = model.Descryption
                }
                );
			return Ok();
		}

        // PUT /cities
        // PUT /api/city
        [HttpPut("cities")]
        [HttpPut("api/city/{id}")]
        public IActionResult Update(Guid id , [FromBody] UpdateCityViewModel model)
        {
            CityStorage.Instance.Update(
                id,
                new City
                {
                    Name = model.Name,
                    Population = model.Population,
                    Descryption = model.Descryption
                }
                );
            return Ok();
        }

        // DELETE /cities
        // DELETE /api/city
        [HttpDelete("cities")]
        [HttpDelete("api/city/{id}")]
        public IActionResult Delete(Guid id)
        {
            CityStorage.Instance.Delete(id);
            return Ok();
        }
    }
}
