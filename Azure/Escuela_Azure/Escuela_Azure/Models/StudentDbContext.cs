using Microsoft.EntityFrameworkCore;

namespace Escuela_Azure.Models
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
    }


}
