using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Smith_Swimming_School.Models;
using System.Text.RegularExpressions;
using Group = Smith_Swimming_School.Models.Group;

namespace Smith_Swimming_School.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Swimmer> Swimmers { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>() {
                new IdentityRole { Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
                new IdentityRole { Name = "Coach", NormalizedName = "COACH" },
                new IdentityRole { Name = "Visitor", NormalizedName = "VISITOR" },
                new IdentityRole { Name = "Swimmer", NormalizedName = "SWIMMER" }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            List<IdentityUser> users = new List<IdentityUser>()
            {
                    //Admin
                    new IdentityUser {
                        UserName="admin@3s.com", NormalizedUserName= "ADMIN@3S.COM",
                        Email = "admin@3s.com", NormalizedEmail="ADMIN@3S.COM",
                        PhoneNumber="653124875", EmailConfirmed = true
                    },
                    //Visitor
                    new IdentityUser {
                        UserName="lucia.sanchiz@gmail.com", NormalizedUserName= "LUCIA.SANCHIZ@GMAIL.COM",
                        Email = "lucia.sanchiz@gmail.com", NormalizedEmail="LUCIA.SANCHIZ@GMAIL.COM",
                        PhoneNumber="685214739", EmailConfirmed = true
                    },
                    //Coach
                    new IdentityUser {
                        UserName="paco.montoro@3s.com", NormalizedUserName= "PACO.MONTORO@3S.COM",
                        Email = "paco.montoro@3s.com", NormalizedEmail="PACO.MONTORO@3S.COM",
                        PhoneNumber="632514785", EmailConfirmed = true
                    },
                    //Coach
                    new IdentityUser {
                        UserName="marta.alonso@3s.com", NormalizedUserName= "MARTA.ALONSO@3S.COM",
                        Email = "marta.alonso@3s.com", NormalizedEmail="MARTA.ALONSO@3S.COM",
                        PhoneNumber="632541278", EmailConfirmed = true
                    },
                    //Swimmer
                    new IdentityUser {
                        UserName="maria.guerrero@gmail.com", NormalizedUserName= "MARIA.GUERRERO@GMAIL.COM",
                        Email = "maria.guerrero@gmail.com", NormalizedEmail="MARIA.GUERRERO@GMAIL.COM",
                        PhoneNumber="685214378", EmailConfirmed = true
                    },
                    //Swimmer
                    new IdentityUser {
                        UserName="raul.hernandez@gmail.com", NormalizedUserName= "RAUL.HERNANDEZ@GMAIL.COM",
                        Email = "raul.hernandez@gmail.com", NormalizedEmail="RAUL.HERNANDEZ@GMAIL.COM",
                        PhoneNumber="693251487", EmailConfirmed = true
                    },
                    //Swimmer
                    new IdentityUser {
                        UserName="martin.sanchez@gmail.com", NormalizedUserName= "MARTIN.SANCHEZ@GMAIL.COM",
                        Email = "martin.sanchez@gmail.com", NormalizedEmail="MARTIN.SANCHEZ@GMAIL.COM",
                        PhoneNumber="602145318", EmailConfirmed = true
                    },
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Admin1234$");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Lucia1234$");

            builder.Entity<IdentityUser>().HasData(users);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> {
                    UserId = users[0].Id,
                    RoleId = roles.Single(r => r.Name == "Administrator").Id
                },
                new IdentityUserRole<string> {
                    UserId = users[1].Id,
                    RoleId = roles.Single(r => r.Name == "Visitor").Id
                },
                new IdentityUserRole<string> {
                    UserId = users[2].Id,
                    RoleId = roles.Single(r => r.Name == "Coach").Id
                },
                new IdentityUserRole<string> {
                    UserId = users[3].Id,
                    RoleId = roles.Single(r => r.Name == "Coach").Id
                }
            );

            builder.Entity<Coach>().HasData(
                new Coach {
                    Name = "Paco Montoro",
                    Phone_Number = "632514785",
                    CoachUser = "paco.montoro@3s.com"
                },
                new Coach {
                    Name = "Marta Alonso",
                    Phone_Number = "632541278",
                    CoachUser = "marta.alonso@3s.com"
                }
            );
            builder.Entity<Swimmer>().HasData(
                new Swimmer
                {
                    Name = "Maria Guerrero",
                    Genre = Genre.Woman,
                    Birth_Date = new DateTime(2019, 10, 20),
                    Phone_Number = "685214378",
                    SwimmerUser = "maria.guerrero@gmail.com",
                },
                new Swimmer
                {
                    Name = "Raul Hernandez",
                    Genre = Genre.Man,
                    Birth_Date = new DateTime(2018, 06, 15),
                    Phone_Number = "693251487",
                    SwimmerUser = "raul.hernandez@gmail.com",
                },
                new Swimmer
                {
                    Name = "Martin Sanchez",
                    Genre = Genre.Man,
                    Birth_Date = new DateTime(1995, 03, 10),
                    Phone_Number = "602145318",
                    SwimmerUser = "martin.sanchez@gmail.com",
                }
            );
            builder.Entity<Course>().HasData(
                new Course { Id_Coach = 2, Title = "Swim Training for Endurance", TotalPlaces = 25 },
                new Course { Id_Coach = 1, Title = "Breaststroke Fundamentals", TotalPlaces = 30}
            );
            builder.Entity<Group>().HasData(
                new Group
                {
                    Level = Level.YoungSwimmerLvl1,
                    Start_Date = new DateTime(2025, 01, 01, 08, 00, 00),
                    End_Date = new DateTime(2025, 01, 31, 17, 00, 00),
                    Places = 20
                },
                new Group
                {
                    Level = Level.AdultLearning,
                    Start_Date = new DateTime(2024, 10, 01, 09, 00, 00),
                    End_Date = new DateTime(2024, 01, 30, 18, 30, 00),
                    Places = 15
                },
                new Group
                {
                    Level = Level.YoungSwimmerLvl3,
                    Start_Date = new DateTime(2024, 10, 01, 10, 00, 00),
                    End_Date = new DateTime(2024, 12, 31, 14, 00, 00),
                    Places = 10
                });
            builder.Entity<Enrollment>().HasData(
               new Enrollment {
                   Id_Course = 2,
                   Id_Grouping = 1,
                   Id_Swimmer = 1                   
               },
               new Enrollment {
                   Id_Course = 1,
                   Id_Grouping = 2,
                   Id_Swimmer = 3
               }
            );
            builder.Entity<Report>().HasData(
                new Report
                {
                    ProgressReport = "El alumno progresa adecuadamente",
                    Id_Enrollment = 2
                }
            );

        }

    }
}
