using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_Business_Logic.Models;

namespace ASP.NET_Core_Business_Logic.Contracts
{
	public interface IProductService
	{
		Task<List<ProductViewModel>> GetAllProductsAsync();
		Task AddProductAsync(ProductFormModel model);
		Task EditProductAsync(ProductFormModel model);
		Task DeleteProductAsync(ProductFormModel model);
	}
}
