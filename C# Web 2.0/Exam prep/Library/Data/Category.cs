﻿using System.ComponentModel.DataAnnotations;

namespace Library.Data
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required] [MaxLength(50)]
		public string Name { get; set; } = null!;

		public ICollection<Book> Books { get; set; } = new List<Book>();

	}
}
