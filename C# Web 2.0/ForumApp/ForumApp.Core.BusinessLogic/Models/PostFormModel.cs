using System.ComponentModel.DataAnnotations;
using static ForumApp.Data.Common.DataConstants.PostConstants;

namespace ForumApp.Core.BusinessLogic.Models
{
	public class PostFormModel
	{
		[Required]
		[StringLength(TitleMaxLength,MinimumLength = TitleMinLength)]
		public string Title { get; set; } = null!;

		[Required]
		[StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
		public string Content { get; set; } = null!;

	}
}
