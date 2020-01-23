using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Reminder.WebApi.Infrastructure
{
	// Чтобы реализовать фильтр обработки запроса
	// необходимо отнаследоваться от базового класса и переопределить необходимый метод
	public class ValidationFilterAttribute : ActionFilterAttribute
	{
		// Данный метод вызывается перед выполнением действия контроллера
		// Но после того как выполнена привязка модели (model binding)
		// Таким образом, можно выполнить проверки состояния модели
		// И в случае, если она некорректная - вернуть результат, не вызывая действие контроллера
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			if (context.ActionArguments.Values.Any(item => item == default))
			{
				context.Result = new BadRequestResult();
			}

			if (!context.ModelState.IsValid)
			{
				context.Result = new BadRequestObjectResult(context.ModelState);
			}
		}
	}
}
