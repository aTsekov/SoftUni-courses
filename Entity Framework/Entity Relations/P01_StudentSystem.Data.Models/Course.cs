
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Common;


namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
                Students = new HashSet<Student>();
                Homeworks = new HashSet<Homework>();
                Resources = new HashSet<Resource>();
        }

        [Key]
        public int CourseId { get; set; }

        [Required]
        [Unicode(true)]
        [MaxLength(GlobalConstants.CourseNameMaxLength)]
        public string Name { get; set; }

        [Unicode(true)]
        [MaxLength]
        [AllowNull]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        [InverseProperty("Courses")]
        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

        
    }
}
