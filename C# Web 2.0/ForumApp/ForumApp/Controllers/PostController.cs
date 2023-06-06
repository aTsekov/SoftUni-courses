

using ForumApp.Core.BusinessLogic.Contracts;
using ForumApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    public class PostController : Controller
	{
		//Inject the the service from the middle layer through the constructor and assign it to a variable to use it
		private readonly IPostService postService;

		public PostController(IPostService _postService)
		{ 
			this.postService = _postService;
		}
		public async Task<IActionResult> All()
		{
			var model = await postService.GetAllPostsAsync();
			return View(model);
		}
	}
}
