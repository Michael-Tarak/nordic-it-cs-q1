using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Reminder.Storage.Exceptions;

namespace Reminder.WebApi.Infrastructure
{
	// Чтобы реализовать фильтр обработки запроса
	// необходимо отнаследоваться от базового класса и переопределить необходимый метод
	public class StatusCodeExceptionFilterAttribute : ActionFilterAttribute
	{
		// Данный метод вызывается после выполнения действия контроллера
		// Но перед тем, как сгенерировать результат
		// Таким образом, можно подменить результат выполнения действия контроллера
		// В свойстве Exception содержится исключение, сгенерированное в ходе выполнения действия 
		// Или null в случае успешного выполнения действия
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			// Фича C# 7.* с использованием конструкции switch с проверкой типов
			// Еще такую конструкцию называют как "сопоставление с образцом" или pattern matching

			switch(context.Exception)
			{
				case ReminderItemNotFoundException _:
					context.ExceptionHandled = true;
					context.Result = new NotFoundResult();
					break;

				case ReminderItemDuplicateException _:
					context.ExceptionHandled = true;
					context.Result = new ConflictResult();
					break;

				default:
					break;
			}
		}
	}
}
