using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reminder.Storage;
using Reminder.WebApi.Infrastructure;
using Reminder.WebApi.ViewModels;

namespace Reminder.WebApi.Controllers
{
	// В прошлой версии кода, во всех методах контроллера были дублирующиеся поверки вида
	// if (!ModelState.IsValid) { .. }
	// Чтобы избавится от них, вся промежуточная функциональность, а именно
	//  * Валидация модели
	//  * Конвертация исключительных ситуаций в коды ошибки
	// была вынесена в отдельные фильтры обработки запроса
	// Этот механизм фильтров предоставляет фреймворк Mvc, а реализуются они с помощью атрибутов C#
	[Route("api/reminders")]
	[ValidationFilter]
	[StatusCodeExceptionFilter]
	public class ReminderController : Controller
	{
		private readonly ILogger _logger;
		private readonly IReminderStorage _storage;

		public ReminderController(ILogger<ReminderController> logger, IReminderStorage storage)
		{
			_logger = logger;
			_storage = storage;
		}

		[HttpPost(Name = nameof(Create))]
		public IActionResult Create([FromBody] CreateReminderItemViewModel model)
		{
			var itemId = Guid.TryParse(model.Id, out var id) ? id : Guid.NewGuid();
			var item = new ReminderItem(
				itemId,
				model.ContactId,
				model.Message,
				DateTimeOffset.FromUnixTimeMilliseconds(model.DateTimeUtc));

			_storage.Add(item);
			return CreatedAtRoute(nameof(GetById), new { item.Id }, new ReminderItemViewModel(item));
		}

		[HttpPut("{id}", Name = nameof(Update))]
		public IActionResult Update(Guid id, [FromBody] UpdateReminderItemViewModel model)
		{
			var existsItem = _storage.FindById(id);
			var item = new ReminderItem(
				id,
				existsItem.ContactId,
				model.Message,
				DateTimeOffset.FromUnixTimeMilliseconds(model.DateTimeUtc),
				model.Status);

			_storage.Update(item);
			return Ok();
		}

		[HttpDelete("{id}", Name = nameof(Delete))]
		public IActionResult Delete(Guid id)
		{
			_storage.Delete(id);
			return NoContent();
		}

		[HttpPost("prune")]
		public IActionResult Clear()
		{
			_storage.Clear();
			return Ok();
		}

		[HttpGet("{id}", Name = nameof(GetById))]
		public IActionResult GetById(Guid id)
		{
			var item = _storage.FindById(id);
			var model = new ReminderItemViewModel(item);
			return Ok(model);
		}

		[HttpGet(Name = nameof(GetAll))]
		public IActionResult GetAll([FromQuery] ReminderItemFilterViewModel filter)
		{
			var result = _storage.FindBy(
				new ReminderItemFilter(
					page: new PageInfo((uint)filter.PageNumber, (uint)filter.PageSize),
					datetimeUtc: filter.DateTimeUtc.HasValue 
						? DateTimeOffset.FromUnixTimeMilliseconds(filter.DateTimeUtc.Value) 
						: default,
					status: filter.Status
				)
			);
			var model = new PagedViewModel(result);
			return Ok(model);
		}
	}
}
