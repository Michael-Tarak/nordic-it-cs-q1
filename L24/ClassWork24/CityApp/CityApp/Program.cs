using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System;

namespace CityApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                BuildWebHostBuilder(args)
                    .Build()
                    .Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                LogManager.Shutdown();
            }
            Console.ReadKey();
        }

        private static IWebHostBuilder BuildWebHostBuilder(string[] args)
        {
            return WebHost
                .CreateDefaultBuilder()
                .ConfigureLogging(builder =>
                    builder
                        .AddConsole()
                        .AddDebug()
                )
                .UseStartup<Startup>()
                .UseNLog();
        }
    }
}
