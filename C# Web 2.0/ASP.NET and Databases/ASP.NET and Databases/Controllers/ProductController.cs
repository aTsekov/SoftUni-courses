using ASP.NET_Core_Business_Logic.Contracts;
using ASP.NET_Core_Business_Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_and_Databases.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService productService;
		//Constructor injection. We declear what we need >inject it in the ctor and then we receive it when initialized 
		public ProductController(IProductService _productService)
		{
			this.productService = _productService;
		}
		public async Task<IActionResult> All()
		{
			var model = await productService.GetAllProductsAsync();
			return View(model);
		}

		public async Task<IActionResult> Add()
		{
			var model = new ProductFormModel();
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(ProductFormModel model)
		{
			if (!ModelState.IsValid)
			{
				
				return View(model);
			}

			await productService.AddProductAsync(model);
			return RedirectToAction(nameof(All));
		}
	}
}
