using Microsoft.EntityFrameworkCore;
using OneTableCoreApp.Models;

namespace OneTableCoreApp.Data
{
    public class StudentDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }

    }
}
