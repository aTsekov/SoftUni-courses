using System.ComponentModel.DataAnnotations;
using Type = Homies.Data.Type;

namespace Homies.Models
{
    public class AddEventView
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [StringLength(150, MinimumLength = 15)]
        public string Description { get; set; } = null!;

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        [Required] 
        public TypeViewModel Type { get; set; } = null!;
        public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
