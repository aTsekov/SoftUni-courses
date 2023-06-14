using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data
{
	public class IdentityUserBook
	{
		public string CollectorId { get; set; }

		[ForeignKey(nameof(CollectorId))] 
		public IdentityUser Collector { get; set; } = null!;

		public int BookId { get; set; }

		[ForeignKey(nameof(BookId))] 
		public Book Book { get; set; } = null!;
	}
}
