using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASP.NET_Core_Infrastructure.Common;


namespace ASP.NET_Core_Infrastructure.Model
{
	public class Product
	{
		public Product()
		{
			this.ProductNote = new List<ProductNote>();
		}
		[Key]
		public int Id { get; set; }

		[MaxLength(ModelConstants.MaxNameLength)]
		[Required]
		public string Name { get; set; } = null!;

		[Required]
		public int Quantity { get; set; }

		[Required]
		public decimal Price { get; set; }

		public List<ProductNote> ProductNote { get; set; } 
	}
}
