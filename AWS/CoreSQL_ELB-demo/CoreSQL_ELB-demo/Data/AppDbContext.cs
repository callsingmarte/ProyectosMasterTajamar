using CoreSQL_ELB_demo.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreSQL_ELB_demo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options ) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
    }
}
