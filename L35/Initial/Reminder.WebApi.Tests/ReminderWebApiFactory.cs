using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Reminder.Storage;

namespace Reminder.WebApi.Tests
{
	using MemoryReminderStorage = Storage.Memory.ReminderStorage;
	using WebApiReminderStorage = Storage.WebApi.ReminderStorage;

	// Чтобы упростить конфигурацию запуска веб приложения в тестах
	// Используется пакет Microsoft.AspNetCore.Mvc.Testing
	// В котором присутсвует основной клас - WebApplicationFactory<TStartup>
	// Использование этого класса позволяет не писать рутинный код по конфигурации и запуску веб приложения
	public class ReminderWebApiFactory : WebApplicationFactory<Startup>
	{
		private readonly ReminderItem[] _items;

		public ReminderWebApiFactory(params ReminderItem[] items)
		{
			_items = items ?? Array.Empty<ReminderItem>();
		}

		public WebApiReminderStorage CreateReminderClient() => 
			new WebApiReminderStorage(CreateClient());

		// Метод вызывается для дополнительной конфигурации, перед непоследвенным запуском приложения
		// Что позволяет переопределить сервисы, используемые приложением
		// В частности, заменить реализацию IReminderStorage (указанную в классе Statup) на аналогичную, только с непустой внутренней коррекцией элементов
		// Которые внедряются через конструктор

		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			builder.ConfigureTestServices(services =>
				services.Replace(
					ServiceDescriptor.Singleton<IReminderStorage>(
						new MemoryReminderStorage(_items)
					)
				)
			);
		}
	}
}