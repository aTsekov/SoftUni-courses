using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApp.Data.DataModels;

namespace ForumApp.Data.Seeding
{
	internal class PostSeeder
	{
		internal Post[] GeneratePosts()
		{
			//Create a class array and create a post. Add the post to a collection. This collection will be provided in the PostEntityConfiguration
			ICollection<Post> posts = new HashSet<Post>();
			Post currentPost;

			currentPost = new Post()
			{
				Id = Guid.NewGuid(),
				Title = "My First Post",
				Content =
					"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras placerat vitae quam sed egestas. Pellentesque lobortis felis quam, quis rhoncus."
			};
			posts.Add(currentPost);
			currentPost = new Post()
			{
				Id = Guid.NewGuid(),
				Title = "My Second Post",
				Content =
						"Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..."
			};
			posts.Add(currentPost);
			currentPost = new Post()
			{
				Id = Guid.NewGuid(),
				Title = "My third Post",
				Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse aliquam, ante id sagittis interdum, mi diam lobortis nibh, ac varius magna ex a erat. Praesent pharetra justo vel ante blandit, ac tempus leo lacinia. Pellentesque iaculis quis arcu ut rutrum. Mauris sagittis maximus neque. Sed scelerisque turpis non magna dapibus"
			};
			posts.Add(currentPost);

			return posts.ToArray();

		}

	}
}
