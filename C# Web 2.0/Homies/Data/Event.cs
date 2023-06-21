using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Homies.Data
{
	public class Event
	{
		public Event()
		{
			this.EventsParticipants = new List<EventParticipant>();
		}
		[Key] 
		public int Id { get; set; }

		[Required]
		[MaxLength(20)]
		public string Name { get; set; } = null!;
		[Required]
		[MaxLength(150)]
		public string Description { get; set; } = null!;
		[Required]
		public string OrganiserId { get; set; } = null!;
		[Required]

		public IdentityUser Organiser { get; set; } = null!;

		[Required]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
		public DateTime CreatedOn { get; set; } 
		[Required]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
		public DateTime Start { get; set; } 
		[Required]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
		public DateTime End { get; set; } 

		[Required]
		[ForeignKey(nameof(Type))]
		public int TypeId { get; set; }

		[Required]
		public virtual Type Type { get; set; } = null!;

		public virtual ICollection<EventParticipant> EventsParticipants { get; set; } = null!;


	}
}
