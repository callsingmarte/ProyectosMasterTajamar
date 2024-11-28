using Microsoft.EntityFrameworkCore;
using MultiplesTablesCoreApp.Models;
using System.Security.Cryptography;

namespace MultiplesTablesCoreApp.Data
{
    public class SchoolDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Semilla de Instructors
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor
                {
                    InstructorId = 1,
                    InstructorName = "Prof.Alice Johnson"
                },
                new Instructor
                {
                    InstructorId = 2,
                    InstructorName = "Dr.Bob Smith"
                },
                new Instructor
                {
                    InstructorId = 3,
                    InstructorName = "Dra.Carol Brown"
                }
            );

            // Semilla de Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, CourseTitle = "Introduction to Programming", SeatCapacity = 30, InstructorID = 1 },
                new Course { CourseId = 2, CourseTitle = "Database Systems", SeatCapacity = 25, InstructorID = 2 },
                new Course { CourseId = 3, CourseTitle = "Advanced Mathematics", SeatCapacity = 20, InstructorID = 3 }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { StudentId = 1, StudentName = "Juan Pérez" },
                new Student { StudentId = 2, StudentName = "Ana García" },
                new Student { StudentId = 3, StudentName = "Carlos López" }
            );

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { EnrollementId = 1, StudentId = 1, CourseId = 1 },
                new Enrollment { EnrollementId = 2, StudentId = 1, CourseId = 2 },
                new Enrollment { EnrollementId = 3, StudentId = 2, CourseId = 3 },
                new Enrollment { EnrollementId = 4, StudentId = 3, CourseId = 1 },
                new Enrollment { EnrollementId = 5, StudentId = 3, CourseId = 2 }
            );
        }
    }
}
