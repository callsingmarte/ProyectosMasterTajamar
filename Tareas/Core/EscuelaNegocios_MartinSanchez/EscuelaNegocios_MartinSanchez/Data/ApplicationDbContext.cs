using EscuelaNegocios_MartinSanchez.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EscuelaNegocios_MartinSanchez.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentClub> StudentsClubs { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "Accounting",
                    OfficeLocation = "Building A, Room 101",
                    Phone = "123-456-7890",
                    Email = "accounting@university.edu"
                },
                new Department
                {
                    Id = 2,
                    Name = "Marketing",
                    OfficeLocation = "Building B, Room 202",
                    Phone = "987-654-3210",
                },
                new Department
                {
                    Id = 3,
                    Name = "Management",
                    OfficeLocation = "Building C, Room 303",
                    Email = "management@university.edu"
                }
            );
            builder.Entity<Club>().HasData(
                new Club
                {
                    Id = 1,
                    Name = "Accounting Student Association",
                    Students = 2,
                    DepartmentId = 1 // ID del departamento "Accounting"
                },
                new Club
                {
                    Id = 2,
                    Name = "Balance Book Club",
                    Students = 1,
                    DepartmentId = 1 // ID del departamento "Accounting"
                },
                new Club
                {
                    Id = 3,
                    Name = "Digital Marketing Club",
                    Students = 2,
                    DepartmentId = 2 // ID del departamento "Marketing"
                },
                new Club
                {
                    Id = 4,
                    Name = "Branding Club",
                    Students = 1,
                    DepartmentId = 2 // ID del departamento "Marketing"
                },
                new Club
                {
                    Id = 5,
                    Name = "Leadership Club",
                    Students = 2,
                    DepartmentId = 3 // ID del departamento "Management"
                },
                new Club
                {
                    Id = 6,
                    Name = "Strategy Club",
                    Students = 1,
                    DepartmentId = 3 // ID del departamento "Management"
                }
            );
            builder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Alice Johnson" },
                new Student { Id = 2, Name = "Bob Smith" },
                new Student { Id = 3, Name = "Charlie Brown" },
                new Student { Id = 4, Name = "Diana Prince" },
                new Student { Id = 5, Name = "Ethan Hunt" },
                new Student { Id = 6, Name = "Fiona Gallagher" },
                new Student { Id = 7, Name = "George Bailey" },
                new Student { Id = 8, Name = "Hannah Montana" },
                new Student { Id = 9, Name = "Ian Malcolm" },
                new Student { Id = 10, Name = "Julia Roberts" }
            );

            builder.Entity<StudentClub>().HasData(
                new StudentClub { Id = 1, StudentId = 1, ClubId = 1 }, // Alice Johnson -> Accounting Student Association
                new StudentClub { Id = 2, StudentId = 1, ClubId = 3 }, // Alice Johnson -> Digital Marketing Club
                new StudentClub { Id = 3, StudentId = 2, ClubId = 2 }, // Bob Smith -> Balance Book Club
                new StudentClub { Id = 4, StudentId = 3, ClubId = 4 }, // Charlie Brown -> Branding Club
                new StudentClub { Id = 5, StudentId = 4, ClubId = 5 }, // Diana Prince -> Leadership Club
                new StudentClub { Id = 6, StudentId = 5, ClubId = 6 }, // Ethan Hunt -> Strategy Club
                new StudentClub { Id = 7, StudentId = 6, ClubId = 1 }, // Fiona Gallagher -> Accounting Student Association
                new StudentClub { Id = 8, StudentId = 7, ClubId = 3 }, // George Bailey -> Digital Marketing Club
                new StudentClub { Id = 9, StudentId = 8, ClubId = 5 } // Hannah Montana -> Leadership Club
            );

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin" },
                new IdentityRole { Id = "2", Name = "ClubAdmin" },
                new IdentityRole { Id = "3", Name = "Student" }
            );

            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    UserName = "",
                }                
            );
        }
    }
}
