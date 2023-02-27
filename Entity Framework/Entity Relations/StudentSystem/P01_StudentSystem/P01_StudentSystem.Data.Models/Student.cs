using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Common;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            StudentsCourses = new HashSet<StudentCourse>();
            Homeworks = new HashSet<Homework>();
        }

        [Key]
        public int StudentId { get; set; } 

        [Required]
        [MaxLength(GlobalConstants.StudentNameMaxLength)]
        [Unicode(true)]
        public string Name { get; set; } = null!;

        [StringLength(GlobalConstants.PhoneMaxMinLength,MinimumLength = GlobalConstants.PhoneMaxMinLength)] // the min and should not be here. 
        [Unicode(false)]
        
        public string? PhoneNumber { get; set; } = null!;

        [Required]
        public DateTime RegisteredOn { get; set; } 

        public DateTime? Birthday { get; set; }

      
        public virtual ICollection<StudentCourse> StudentsCourses { get; set; } 

        public virtual ICollection<Homework> Homeworks { get; set; }

    }
}