using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using MongoDBSynopsis.Core.ApplicationService;
using MongoDBSynopsis.Core.ApplicationService.Services;
using MongoDBSynopsis.Core.DomainService;
using MongoDBSynopsis.Infrastructure;
using MongoDBSynopsis.Infrastructure.Repositories;

namespace MongoDBSynopsis.Controller
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("AllowSpecificOrigin",
					builder => builder
						.WithOrigins("http://localhost:59462").AllowAnyHeader().AllowAnyMethod()
					);
			});

			services.AddSingleton((s) =>
			new Client(new MongoClient("mongodb+srv://<user>:<pw>@mongodbsynopsis-cluster.gzxog.mongodb.net/MongoDBSynopsis-Database?retryWrites=true&w=majority")));

			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IProductSeriesService, ProductSeriesService>();
			services.AddScoped<IManufacturerService, ManufacturerService>();

			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IProductSeriesRepository, ProductSeriesRepository>();
			services.AddScoped<IManufacturerRepository, ManufacturerRepository>();

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseCors("AllowSpecificOrigin");

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
