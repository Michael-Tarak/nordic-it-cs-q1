using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reminder.Storage;
using Reminder.Storage.SqlServer;

namespace Reminder.WebApi
{
	// Здесь представлен веб проект для фреймворка .net core 3.0 с несколькими измененями
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// Метод AddMvc() который использовался в .net core 2.* заменился на аналогичный метод AddControllers() с более четким и понятным именованием
		// Так, сразу видно, что данный метод регистрирует все контроллеры и необходмые для них дополнительные службы в коллекции сервисов для последующего использования 
		public void ConfigureServices(IServiceCollection services)
		{
			// .net core 3.0
			services.AddControllers();
			services.AddSingleton<IReminderStorage>(provider => 
				new ReminderStorage(Configuration.GetConnectionString("Database"))
			);
		}

		// В .net core 2.* маршрутизация и обработка запросов в модели Mvc были тесно связаны
		// И из-за этого невозможно было использовать механизмы маршрутизации в веб приложениях не построенных по модели Mvc
		// В .net core 3.* такое поведение изменено, теперь, маршрутизация и фрейморк Mvc независимы друг от друга
		// Вследствие этого, оригинальный метод UseMvc() разделяется и заменяется на два:
		// Метод UseRouting встраивает средства маршрутизации в обработку запроса
		// Метод UseEndpoints сопоставляет запросы с разным функционалом приложения
		// В нашем случае, достаточно сконфигурировать все маршруты на Mvc контроллеры
		public void Configure(IApplicationBuilder app, IHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			// .net core 3.0
			app.UseRouting();
			app.UseEndpoints(endpoints => endpoints.MapControllers());
		}
	}
}
