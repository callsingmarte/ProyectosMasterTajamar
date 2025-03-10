using Microsoft.EntityFrameworkCore;
using MiAppMVC.Models;

namespace MiAppMVC.Models
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        {

        }

        public DbSet<Product>? Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                 .Property(p => p.Price)
                .HasColumnType("decimal(18,2)"); // Define la precisión y escala para el tipo decimal

            base.OnModelCreating(modelBuilder);
        }
    }
}