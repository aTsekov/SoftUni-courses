using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [Required]
        [Unicode(true)]
        [MaxLength(GlobalConstants.ResourceNameMaxLength)]
        public string Name { get; set; }

        [Unicode(false)]
        [MaxLength(GlobalConstants.ResourceNameMaxLength)]
        public string Url { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        //This will be FK
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

    }
}
