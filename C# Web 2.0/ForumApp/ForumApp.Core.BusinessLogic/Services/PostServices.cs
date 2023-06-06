using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApp.Core.BusinessLogic.Contracts;
using ForumApp.Core.BusinessLogic.Models;
using ForumApp.Data;
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
	}
}
