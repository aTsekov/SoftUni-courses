﻿using Library.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
	public class BookController : BaseController
	{
		private readonly IBookService bookService;

		public BookController(IBookService _bookService)
		{
			this.bookService = _bookService;
		}
		public async Task<IActionResult> All()
		{
			var model = await bookService.GetAllBooksAsync();

			return View(model);
		}
	}
}
