

using ForumApp.Core.BusinessLogic.Contracts;
using ForumApp.Core.BusinessLogic.Models;
using ForumApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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

		public async Task<IActionResult> Add()
		{
			var model = new PostFormModel();
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Add(PostFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await postService.AddPostAsync(model);
			return RedirectToAction(nameof(All));
		}

		
		[HttpPost]
		public async Task<IActionResult> Edit(string id)
		{

			try
			{
				var postModel = await this.postService.EditProductByIdAsync(id);

				return View(postModel);
			}
			catch (Exception e)
			{
				return this.RedirectToAction("All", "Post");
			}
		}
	}
}
