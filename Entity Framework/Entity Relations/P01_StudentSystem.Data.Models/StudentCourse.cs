
using System.ComponentModel.DataAnnotations.Schema;


namespace P01_StudentSystem.Data.Models
{
    public class StudentCourse
    {
        //Here the PK is a composite key so we would need to use fluent API to create it
        
        

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public Student Student { get; set; }



        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public Course Course { get; set;}

    }
}
