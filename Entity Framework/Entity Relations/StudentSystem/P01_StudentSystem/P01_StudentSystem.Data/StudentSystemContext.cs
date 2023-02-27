using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using P01_StudentSystem.Data.Models;
using System;
using P01_StudentSystem.Data.Common;

namespace P01_StudentSystem.Data
{

    public class StudentSystemContext : DbContext
    {


        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; } = null!;

        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<Resource> Resources { get; set; } = null!;

        public virtual DbSet<Homework> Homeworks { get; set; } = null!;

        public DbSet<StudentCourse> StudentsCourses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GlobalConstants.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Create the composite key here.
            modelBuilder.Entity<StudentCourse>()
                .HasKey(k => new { k.StudentId, k.CourseId });
        }

    }

    
}