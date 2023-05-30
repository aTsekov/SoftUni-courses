using ASP.NET_Core_Business_Logic.Contracts;
using ASP.NET_Core_Business_Logic.Services;
using ASP.NET_Core_Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_and_Databases
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			//Register the service in the Inversion of Control container needed for the DB context and link it with the Connection String located in appsettings.json
			builder.Services.AddDbContext<ShopContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));

			builder.Services.AddScoped<IProductService, ProductService>(); //Add the services from the Business layer so they can be part of the inversion of control.
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}