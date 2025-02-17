using AngularApp1.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularApp1.Server.Context
{
    public class CustomerDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Juan Pérez", Email = "juan.perez@example.com", Phone = "123-456-7890" },
                new Customer { Id = 2, Name = "María López", Email = "maria.lopez@example.com", Phone = "234-567-8901" },
                new Customer { Id = 3, Name = "Carlos Gómez", Email = "carlos.gomez@example.com", Phone = "345-678-9012" },
                new Customer { Id = 4, Name = "Ana Martínez", Email = "ana.martinez@example.com", Phone = "456-789-0123" }
            );
        }
    }
}
