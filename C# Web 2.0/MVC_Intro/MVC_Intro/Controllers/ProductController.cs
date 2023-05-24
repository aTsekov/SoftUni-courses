using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MVC_Intro.Models;

namespace MVC_Intro.Controllers
{
	public class ProductController : Controller
	{
		private IEnumerable<ProductViewModel> _products = new List<ProductViewModel>()
		{
			new ProductViewModel()
			{
				Id = 1,
				Name = "Cheese",
				Price = 7.00
			},
			new ProductViewModel()
			{
				Id = 2,
				Name = "Ham",
				Price = 7.00
			},
			new ProductViewModel()
			{
				Id = 3,
				Name = "Bread",
				Price = 7.00
			}

		};

		public IActionResult All()
		{
			return View(_products);
		}

		public IActionResult ById(int id)
		{
			var product = _products.FirstOrDefault(p => p.Id == id);
			if (product == null)
			{
				return BadRequest();
			}
			return View(product);
		}

		public IActionResult AllAsJson()
		{
			var options = new JsonSerializerOptions
			{
				WriteIndented = true
			};

			return Json(_products, options);
		}

		public IActionResult AllAsText()
		{
			string text = "";

			foreach (var pr in _products)
			{
				text += $"Product {pr.Id}: {pr.Name} - {pr.Price} lv.";
				text += Environment.NewLine;
			}

			return Content(text);// We need to use Content() because the action should return object.
		}
	}
}
