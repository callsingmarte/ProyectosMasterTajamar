using Microsoft.EntityFrameworkCore;
using SqlServerMvcAppSportDb.Models;

namespace SqlServerMvcAppSportDb.Data
{
    public class SportDbContext : DbContext
    {
        public SportDbContext(DbContextOptions<SportDbContext> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasData(
                new Article { ID = 1, Name = "Football", Category = "Ball", Price = 29.99m },
                new Article { ID = 2, Name = "Basketball", Category = "Ball", Price = 34.99m },
                new Article { ID = 3, Name = "Running Shoes", Category = "Footwear", Price = 89.99m }
            );
        }
    }
}
