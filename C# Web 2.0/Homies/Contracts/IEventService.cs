using Homies.Models;

namespace Homies.Contracts
{
	public interface IEventService
	{
		Task<IEnumerable<ViewAllModel>> GetAllEventsAsync();

		Task AddEventAsync(AddEventView model);
		//Task AddBookToCollectionAsync(string userId, BookViewModel book);
		//Task EditBookAsync(AddBookViewModel model, int id);
		//Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();
		//Task<BookViewModel?> GetBookByIdAsync(int id);
		//Task<AddBookViewModel?> GetBookByIdForEditAsync(int id);
		Task<ICollection<ViewJoinedModel>> GetMyEventsAsync(string userId);
		//Task<AddBookViewModel> GetNewAddBookModelAsync();
		//Task RemoveBookFromCollectionAsync(string userId, BookViewModel book);
	}
}
