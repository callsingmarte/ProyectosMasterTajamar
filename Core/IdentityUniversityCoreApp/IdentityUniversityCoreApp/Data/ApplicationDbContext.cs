using IdentityUniversityCoreApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace IdentityUniversityCoreApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Students
            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, StudentName = "Alice Johnson", StudentUser = "alice@student.com" },
                new Student { StudentId = 2, StudentName = "Bob Smith", StudentUser = "bob@student.com" }
            );

           // Seed Instructors
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { InstructorId = 1, InstructorName = "Dr. Emily Brown", OfficeLocation = "Room 101", InstructorUser = "emily@instructor.com" },
                new Instructor { InstructorId = 2, InstructorName = "Prof. John Green", OfficeLocation = "Room 102", InstructorUser = "john@instructor.com" }
            );

            // Seed Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, CourseTitle = "Mathematics 101", SeatCapacity = 30, InstructorId = 1 },
                new Course { CourseId = 2, CourseTitle = "Physics 201", SeatCapacity = 25, InstructorId = 2 }
            );

            // Seed Enrollments
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { EnrollmentId = 1, StudentId = 1, CourseId = 1, LetterGrade = LetterGrade.A },
                new Enrollment { EnrollmentId = 2, StudentId = 2, CourseId = 2, LetterGrade = LetterGrade.B }
            );
        }
    }
}
