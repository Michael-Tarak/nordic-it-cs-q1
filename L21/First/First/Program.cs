using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace First
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup2>();
                });
    }
    public class Startup2
    {
        public void Configure(IApplicationBuilder builder,
            IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                builder.UseDeveloperExceptionPage();
            }
            builder.Use(PostWorldRequest);
            builder.Use(GetHelloRequest);
            builder.Run(GetAllRequest);
        }

        private static Task PostWorldRequest(HttpContext context, Func<Task> next)
        {
            if (context.Request.Method.ToUpper() == "POST" &&
                context.Request.Path.StartsWithSegments("/world"))
            {
                context.Response.StatusCode = 221;
                return context.Response.WriteAsync(" Post Hello World");
            }
            return next();
        }

        private static Task GetHelloRequest(HttpContext context, Func<Task> next)
        {
            if (context.Request.Method.ToUpper() == "GET" &&
                context.Request.Path.StartsWithSegments("/hello"))
            {
                context.Response.StatusCode = 220;
                return context.Response.WriteAsync("Get Hello World");
            }
            return next();
        }

        private static Task GetAllRequest(HttpContext context)
        {
            throw new Exception("Some");
        }
    }
}
