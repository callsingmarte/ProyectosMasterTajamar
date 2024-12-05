using Microsoft.EntityFrameworkCore;
using PedidosBlazor.Models;

namespace PedidosBlazor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Articles
            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    ID = 1,
                    Name = "Laptop",
                    Category = "Electronics",
                    Price = 1200.00m
                },
                new Article
                {
                    ID = 2,
                    Name = "Smartphone",
                    Category = "Electronics",
                    Price = 800.00m
                },
                new Article
                {
                    ID = 3,
                    Name = "Table",
                    Category = "Furniture",
                    Price = 150.00m
                }
            );

            // Seed Orders
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderID = 1,
                    CompanyName = "TechCorp",
                    Quantity = 10,
                    OrderDate = new DateTime(2023, 11, 15),
                    ArticleID = 1
                },
                new Order
                {
                    OrderID = 2,
                    CompanyName = "GadgetStore",
                    Quantity = 5,
                    OrderDate = new DateTime(2023, 12, 01),
                    ArticleID = 2
                },
                new Order
                {
                    OrderID = 3,
                    CompanyName = "HomeFurnishings",
                    Quantity = 20,
                    OrderDate = new DateTime(2023, 10, 10),
                    ArticleID = 3
                }
            );
        }
    }
}
