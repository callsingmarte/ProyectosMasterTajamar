using Microsoft.EntityFrameworkCore;
using MvcAppAws_MartinSanchez.Models;

namespace MvcAppAws_MartinSanchez.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Alumno> Alumnos { get; set; }       
    }
}
