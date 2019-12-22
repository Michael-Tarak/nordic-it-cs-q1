using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace L23_C01_asp_net_core_app
{
	public class Startup
	{
		// Application services configuration
		// Service can be understood as any class
		// Since the application is being developed using the framework (controllers, for example, created a framework for us, we never wrote new CityController () with this)
		// That framework itself controls the lifetime of all classes. And in order to correctly construct an object, the framework needs to know about its dependencies
		// All of these dependencies are configured in this method
		// MVC itself, consists of many services that are embedded in the application by calling the AddMvc() extension method
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc(options =>
					{
						options.RespectBrowserAcceptHeader = true;
					}
				)
				.AddXmlSerializerFormatters();
			services.AddSwaggerGen(options =>
				{
					options.SwaggerDoc("v1",
						new OpenApiInfo
						{
							Title = "Cities API",
							Version = "V1"
						}
					);
				}
			);
		}

		// Request pipeline configuration
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStatusCodePages();
			app.UseSwagger();
			app.UseSwaggerUI(configuration => configuration.SwaggerEndpoint("/swagger/v1/swagger.json", "Cities API V1"));
			app.UseMvc();
		}
	}
}
