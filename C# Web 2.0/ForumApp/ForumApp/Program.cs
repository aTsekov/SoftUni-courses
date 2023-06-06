using ForumApp.Core.BusinessLogic.Contracts;
using ForumApp.Core.BusinessLogic.Services;
using ForumApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ForumApp
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<ForumAppDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"))); //provide the DBContext and the connection string to the DI
			//Add the services from the Business layer so they can be part of the inversion of control.
			builder.Services.AddScoped<IPostService, PostServices>();
			

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