using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApp.Core.BusinessLogic.Contracts;
using ForumApp.Core.BusinessLogic.Models;
using ForumApp.Data;
using ForumApp.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Core.BusinessLogic.Services
{
	public class PostServices :IPostService
	{
		//In Post services we actually create the CRUD operations and map the model with the DB model and perform the actions in the DB. 
		private readonly ForumAppDbContext forumAppDbContext;

		public PostServices(ForumAppDbContext _forumAppDbContext)
		{
			this.forumAppDbContext = _forumAppDbContext;
		}

		public async Task<List<PostViewModel>> GetAllPostsAsync()
		{
			return await forumAppDbContext.Posts.Select(p => new PostViewModel
			{
				Id = p.Id,
				Title = p.Title,
				Content = p.Content

			}).ToListAsync();
		}

		public async Task AddPostAsync(PostFormModel model)
		{
			var newPost = new Post()
			{
				Title = model.Title,
				Content = model.Content
			};

			await this.forumAppDbContext.Posts.AddAsync(newPost);
			await forumAppDbContext.SaveChangesAsync();

		}

		public async Task<PostFormModel> EditProductByIdAsync(string id)
		{
			Post postToEdit = await this.forumAppDbContext.Posts.FirstAsync(p => p.Id.ToString() == id);

			return  new PostFormModel()
			{
				Title = postToEdit.Title,
				Content = postToEdit.Content
			};
		}

		public Task DeleteProductAsync(PostFormModel model)
		{
			throw new NotImplementedException();
		}
	}
}
