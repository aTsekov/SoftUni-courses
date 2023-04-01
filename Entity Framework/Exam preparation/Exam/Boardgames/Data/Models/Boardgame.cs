using Boardgames.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class Boardgame
    {
        

        public Boardgame()
        {
            BoardgamesSellers = new HashSet<BoardgameSeller>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; } = null!;

        [Required]
        public double Rating { get; set; }
        [Required]
        public int YearPublished { get; set; }
        [Required]

        public CategoryType CategoryType { get; set; }

        [Required] public string Mechanics { get; set; } = null!;

        [ForeignKey(nameof(Creator))]
        [Required]
        public int CreatorId { get; set; }
        public virtual Creator Creator { get; set; }

        public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    }
}
