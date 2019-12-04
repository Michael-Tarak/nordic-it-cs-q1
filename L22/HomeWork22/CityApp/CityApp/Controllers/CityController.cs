using Microsoft.AspNetCore.Mvc;

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
        public IActionResult List() =>
            Json(CityStorage.Instance.GetAll());

        // POST /cities
        // POST /api/city/post
        [HttpPost("cities")]
		[HttpPost("api/city/post")]
		public IActionResult Create([FromBody] City city)
		{
			CityStorage.Instance.Create(city);
			return Ok();
		}

        // PUT /cities
        // PUT /api/city/put
        [HttpPut("cities")]
        [HttpPut("api/city/put")]
        public IActionResult Update([FromBody] City city)
        {
            CityStorage.Instance.Update(city);
            return Ok();
        }

        // DELETE /cities
        // DELETE /api/city/put
        [HttpDelete("cities")]
        [HttpDelete("api/city/delete")]
        public IActionResult Delete([FromBody] City city)
        {
            CityStorage.Instance.Delete(city);
            return Ok();
        }
    }
}
