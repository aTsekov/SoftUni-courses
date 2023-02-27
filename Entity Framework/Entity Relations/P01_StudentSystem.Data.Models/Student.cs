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
            StudentCourse = new HashSet<StudentCourse>();
        }

        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.StudentNameMaxLength)]
        [Unicode(true)]
        public string Name { get; set; }

        [StringLength(GlobalConstants.PhoneMaxMinLength,MinimumLength = GlobalConstants.PhoneMaxMinLength)] // the min and should not be here. 
        [Unicode(false)]
        [AllowNull]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime Birthday { get; set; }

        [InverseProperty("Students")]
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

    }
}