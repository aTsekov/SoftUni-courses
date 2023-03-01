using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(GlobalConstants.AlbumNameMaxLength)]
        public string Name { get; set; } = null!;

        public DateOnly ReleaseDate { get; set; } // is the date correct?

    }
}
