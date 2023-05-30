using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_Business_Logic.Contracts;
using ASP.NET_Core_Business_Logic.Models;
using ASP.NET_Core_Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Core_Business_Logic.Services
{
	public class ProductService : IProductService
	{
		private readonly ShopContext dbContext;
		//In Product services we actually create the CRUD operations and map the model with the DB model and perform the action in the DB. 

		public ProductService(ShopContext _dbContext)
		{
			this.dbContext= _dbContext;
		}
		public async Task<List<ProductViewModel>> GetAllProductsAsync()
		{
			return await dbContext.Products
				.Select(p => new ProductViewModel
				{
					Id = p.Id,
					Name = p.Name,
				})
				.ToListAsync();
		}

		public async Task AddProductAsync(ProductFormModel model)
		{
			Product product = new Product
			{
				Name = model.Name,
				Quantity = model.Quantity
			};

			await dbContext.Products.AddAsync(product);
			await dbContext.SaveChangesAsync();
		}

		public Task EditProductAsync(ProductFormModel model)
		{
			throw new NotImplementedException();
		}

		public Task DeleteProductAsync(ProductFormModel model)
		{
			throw new NotImplementedException();
		}
	}
}
