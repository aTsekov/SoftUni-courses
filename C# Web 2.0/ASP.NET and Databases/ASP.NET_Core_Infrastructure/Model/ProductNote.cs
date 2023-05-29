using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Core_Infrastructure.Model
{
	public class ProductNote
	{
		[Required]
		public int Id { get; set; }
		public string? Note { get; set; }
		public DateTime DateTime { get; set; }

		public int ProductId { get; set; }

		[ForeignKey(nameof(ProductId))]
		public Product Product { get; set; } = null!;
	}
}
