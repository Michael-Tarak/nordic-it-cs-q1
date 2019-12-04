using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CityApp
{
	public class Program
	{
		private static void Main(string[] args)
		{
			BuildWebHostBuilder(args)
				.Build()
				.Run();

			Console.ReadKey();
		}

		private static IWebHostBuilder BuildWebHostBuilder(string[] args)
		{
			return WebHost
				.CreateDefaultBuilder()
				.UseStartup<Startup>();
		}
	}
}
