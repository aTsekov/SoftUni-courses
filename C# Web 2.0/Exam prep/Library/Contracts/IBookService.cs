using Library.Models;

namespace Library.Contracts
{
	public interface IBookService
	{
		public Task<List<AllBooksModel>> GetAllBooksAsync();
		Task<ICollection<MyBooksModel>> GetMyBooksAsync(string userId);
	}
}
