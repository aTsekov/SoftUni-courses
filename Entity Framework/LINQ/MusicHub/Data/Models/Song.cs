using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicHub.Data.Models.Enums;

namespace MusicHub.Data.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(GlobalConstants.SongNameMaxLength)]
        public string Name { get; set; } = null!;

        public TimeSpan Duration { get; set; }

        public DateTime CreatedOn { get; set; } 

        public Genre Genre { get; set; }

        //[ForeignKey(nameof())]
        public int? AlbumId{ get; set; }

        //[ForeignKey(nameof())]
        public int? WriterId { get; set; }

        public decimal Price { get; set; }
    }
}
