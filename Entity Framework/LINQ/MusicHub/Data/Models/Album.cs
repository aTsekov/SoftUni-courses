using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data.Models
{
    public class Album
    {

        public Album()
        {
            this.Songs = new HashSet<Song>();
        }
        [Key]
        public int Id { get; set; }

        [MaxLength(GlobalConstants.AlbumNameMaxLength)]
        public string Name { get; set; } = null!;

        public DateTime ReleaseDate { get; set; } 
        
        [NotMapped] // This attribute will ensure it will not be created in the DB. It's just here in the class. 
        public decimal Price
            => this.Songs.Sum(s => s.Price);

        [ForeignKey(nameof(ProducerId))]
        public int? ProducerId { get; set; }

        public virtual Producer? Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; }

    }
}
