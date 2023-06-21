using System.ComponentModel.DataAnnotations;

namespace Homies.Data
{
	public class Type
	{
		[Key]
		public int  Id { get; set; }

		[Required]
		[StringLength(15)] 
		public string Name { get; set; } = null!;

		public virtual ICollection<Event> Events { get; set; } = new List<Event>();
	}
}
