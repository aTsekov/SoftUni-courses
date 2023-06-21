using System.Globalization;
using Library.Contracts;
using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
	
	public class BookService : IBookService
	{
		private readonly LibraryDbContext libraryDbContext;

		public BookService(LibraryDbContext _libraryDbContext)
		{
			this.libraryDbContext = _libraryDbContext;
		}
		public async Task<List<AllBooksModel>> GetAllBooksAsync()
		{
			return await this.libraryDbContext.Books.Select( b => new AllBooksModel
			{
				Id = b.Id,
				Title = b.Title,
				ImageUrl = b.ImageUrl,
				Author = b.Author,
				Category = b.Category.Name,
				Rating = b.Rating.ToString(CultureInfo.InvariantCulture)
			}).ToListAsync();
		}

		public Task<ICollection<MyBooksModel>> GetMyBooksAsync(string userId)
		{
			throw new NotImplementedException();
		}

		//public async Task<ICollection<MyBooksModel>> GetMyBooksAsync(string userId)
		//{
		//	//return await this.libraryDbContext.IdentityUsers.Where(ub => ub.CollectorId == userId)
		//	//	.Select(b => new MyBooksModel
		//	//	{

		//	//	});
		//}
	}
	
	
}
