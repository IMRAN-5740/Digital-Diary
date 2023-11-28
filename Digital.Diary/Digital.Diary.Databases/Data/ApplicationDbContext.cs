using Digital.Diary.Models.EntityModels.Academic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital.Diary.Databases.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<CrTable> CrTables { get; set; }
        public DbSet<Dean> Deans { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        public DbSet<TeacherFaculty> TeachersFaculty { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // Define relationships and constraints

        //    // Teacher to Designation (Many-to-One)
        //    modelBuilder.Entity<Teacher>()
        //        .HasOne(t => t.Designation)
        //        .WithMany()
        //        .HasForeignKey(t => t.DesignationId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    // Teacher to Faculty (Many-to-One)
        //    modelBuilder.Entity<Teacher>()
        //        .HasOne(t => t.Faculty)
        //        .WithMany(f => f.Teachers)
        //        .HasForeignKey(t => t.FacultyId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    // Teacher to Department (Many-to-One)
        //    modelBuilder.Entity<Teacher>()
        //        .HasOne(t => t.Department)
        //        .WithMany(d => d.Teachers)
        //        .HasForeignKey(t => t.DepartmentId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    // Department to Faculty (One-to-One or Many-to-One, based on your design)
        //    modelBuilder.Entity<Department>()
        //        .HasOne(d => d.Faculty)
        //        .WithMany(f => f.Departments)
        //        .HasForeignKey(d => d.FacultyId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    // Dean to Faculty (Many-to-One)
        //    modelBuilder.Entity<Dean>()
        //        .HasOne(d => d.Faculty)
        //        .WithMany(f => f.Deans)
        //        .HasForeignKey(d => d.FacultyId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    // CrTable to Department (Many-to-One)
        //    modelBuilder.Entity<CrTable>()
        //        .HasOne(cr => cr.Department)
        //        .WithMany(d => d.CrTables)
        //        .HasForeignKey(cr => cr.DepartmentId)
        //        .OnDelete(DeleteBehavior.Restrict);

        //    // Other configurations...

        //    // Adjust cascade behaviors as needed
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define relationships and constraints

            // Teacher to Designation (Many-to-One)
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Designation)
                .WithMany()
                .HasForeignKey(t => t.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Teacher to Faculty (Many-to-One)
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Faculty)
                .WithMany(f => f.Teachers)
                .HasForeignKey(t => t.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Teacher to Department (Many-to-One)
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Department)
                .WithMany(d => d.Teachers)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department to Faculty (One-to-One or Many-to-One, based on your design)
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Faculty)
                .WithMany(f => f.Departments)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Dean to Faculty (Many-to-One)
            modelBuilder.Entity<Dean>()
                .HasOne(d => d.Faculty)
                .WithMany(f => f.Deans)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);

            // CrTable to Department (Many-to-One)
            modelBuilder.Entity<CrTable>()
                .HasOne(cr => cr.Department)
                .WithMany(d => d.CrTables)
                .HasForeignKey(cr => cr.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Staff to Designation (Many-to-One)
            modelBuilder.Entity<Staff>()
                .HasOne(s => s.Designation)
                .WithMany()
                .HasForeignKey(s => s.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Staff to Department (Many-to-One)
            modelBuilder.Entity<Staff>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Staffs)
                .HasForeignKey(s => s.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Other configurations...

            // Adjust cascade behaviors as needed
        }




    }
}
