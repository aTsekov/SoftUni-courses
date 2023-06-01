using ForumApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    public class PostController : Controller
	{
		//Inject the ForumAppDbContext through the constructor and assign it to a variable to use it
		private readonly ForumAppDbContext _data;

		public PostController(ForumAppDbContext data)
		{ 
			this._data = data;
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
