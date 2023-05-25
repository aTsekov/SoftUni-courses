using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
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


		//If we want to change the URL so the action is now the name of the method, but whatever it's in the Attribute [ActionName] 
		//We should also change the name of the View to "My-Products"
		[ActionName("My-Products")]
		public IActionResult All(string keyword)
		{
			if (string.IsNullOrWhiteSpace(keyword))
			{
				return View(_products);
			}

			IEnumerable<ProductViewModel> productsAfterSearch =
				_products.Where(p => p.Name.ToLower().Contains(keyword)).ToList();

			return View(productsAfterSearch);
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

		public IActionResult AllAsTextFile()
		{
			StringBuilder sb = new StringBuilder();
			foreach (var pr in _products)
			{
				sb.AppendLine($"Product {pr.Id}: {pr.Name} - {pr.Price} lv.");
			}

			Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");
			//By adding the content disposition header and the additional value/setting "attachment" we make it possible for the file to be downloaded. Without "attachment" it will be opened by the browser in a new tab. 

			return File(Encoding.UTF8.GetBytes(sb.ToString().TrimEnd()), "text/plain");
		}

	}
}
