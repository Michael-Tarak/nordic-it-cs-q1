using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace L23_C01_asp_net_core_app
{
	public class Program
	{
		public static void Main(string[] args) => CreateWebHostBuilder(args)
			.Build()
			.Run();

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}
