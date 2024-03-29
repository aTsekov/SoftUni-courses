﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data
{
	public class Book
	{
		[Key]
		public int Id { get; set; }

		[Required] 
		[MaxLength(50)] 
		public string Title { get; set; } = null!;

		[Required]
		[MaxLength(50)]
		public string  Author { get; set; } = null!;

		[Required]
		[MaxLength(5000)]
		public string Description { get; set; } = null!;

		[Required]
		public string ImageUrl { get; set; } = null!;

		[Required]
		public  decimal Rating { get; set; }

		[Required]
		public int CategoryId { get; set; }

		[ForeignKey(nameof(CategoryId))]
		public virtual Category Category { get; set; } = null!;

		public ICollection<IdentityUserBook> UsersBooks = new List<IdentityUserBook>();
	}
}
