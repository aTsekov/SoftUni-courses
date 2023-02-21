using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EFCore_Into.Models;

namespace EFCore_Into.Data
{
    public partial class SoftUniContext : DbContext
    {
        public SoftUniContext()
        {
        }

        public SoftUniContext(DbContextOptions<SoftUniContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeesWithSalaryOver30000> EmployeesWithSalaryOver30000s { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Town> Towns { get; set; } = null!;
        public virtual DbSet<VEmployeeNameJobTitle3> VEmployeeNameJobTitle3s { get; set; } = null!;
        public virtual DbSet<VEmployeesHiredAfter2000> VEmployeesHiredAfter2000s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne(d => d.Town)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.TownId)
                    .HasConstraintName("FK_Addresses_Towns");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departments_Employees");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Employees_Addresses");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Departments");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Employees_Employees");

                entity.HasMany(d => d.Projects)
                    .WithMany(p => p.Employees)
                    .UsingEntity<Dictionary<string, object>>(
                        "EmployeesProject",
                        l => l.HasOne<Project>().WithMany().HasForeignKey("ProjectId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EmployeesProjects_Projects"),
                        r => r.HasOne<Employee>().WithMany().HasForeignKey("EmployeeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EmployeesProjects_Employees"),
                        j =>
                        {
                            j.HasKey("EmployeeId", "ProjectId");

                            j.ToTable("EmployeesProjects");

                            j.IndexerProperty<int>("EmployeeId").HasColumnName("EmployeeID");

                            j.IndexerProperty<int>("ProjectId").HasColumnName("ProjectID");
                        });
            });

            modelBuilder.Entity<EmployeesWithSalaryOver30000>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VEmployeeNameJobTitle3>(entity =>
            {
                entity.ToView("V_EmployeeNameJobTitle3");
            });

            modelBuilder.Entity<VEmployeesHiredAfter2000>(entity =>
            {
                entity.ToView("V_EmployeesHiredAfter2000");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
