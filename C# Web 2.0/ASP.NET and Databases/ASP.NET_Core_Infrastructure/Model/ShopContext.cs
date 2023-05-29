using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Infrastructure.Model
{
	public class ShopContext :DbContext
	{
		public ShopContext(DbContextOptions<ShopContext> options)
		:base(options)
		{
			
		}

		public DbSet<Product> Products { get; set; }

		public DbSet<ProductNote> ProductNotes { get; set; }
	}
}
