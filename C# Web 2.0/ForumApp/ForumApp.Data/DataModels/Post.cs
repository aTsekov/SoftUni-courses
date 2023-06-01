using System.ComponentModel.DataAnnotations;
using static ForumApp.Data.Common.DataConstants.Post;

namespace ForumApp.Data.DataModels
{
	public class Post
	{
		[Key]
		public Guid Id { get; set; } //use init setters only for properties, which won't be changed after the initialization. For example,the Id property will always be the same.
		[Required]
		[MaxLength(TitleMaxLength)]
		public string Title { get; set; } = null!;

		[Required]
		[MaxLength(ContentMaxLength)]
		public string Content { get; set; }= null!;
	}
}
