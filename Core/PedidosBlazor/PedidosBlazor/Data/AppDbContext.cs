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
                    Name = "Soccer Ball",
                    Category = "Sports Equipment",
                    Price = 25.99m
                },
                new Article
                {
                    ID = 2,
                    Name = "Running Shoes",
                    Category = "Footwear",
                    Price = 80.00m
                },
                new Article
                {
                    ID = 3,
                    Name = "Boxing Gloves",
                    Category = "Sports Equipment",
                    Price = 45.50m
                },
                new Article
                {
                    ID = 4,
                    Name = "Basketball",
                    Category = "Sports Equipment",
                    Price = 30.00m
                },
                new Article
                {
                    ID = 5,
                    Name = "Tennis Racket",
                    Category = "Sports Equipment",
                    Price = 120.00m
                }
            );

            // Seed Orders
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderID = 1,
                    CompanyName = "Sports World",
                    Quantity = 15,
                    OrderDate = new DateTime(2023, 10, 12),
                    ArticleID = 1
                },
                new Order
                {
                    OrderID = 2,
                    CompanyName = "Footwear Co.",
                    Quantity = 20,
                    OrderDate = new DateTime(2023, 11, 05),
                    ArticleID = 2
                },
                new Order
                {
                    OrderID = 3,
                    CompanyName = "Fitness Depot",
                    Quantity = 10,
                    OrderDate = new DateTime(2023, 09, 15),
                    ArticleID = 3
                },
                new Order
                {
                    OrderID = 4,
                    CompanyName = "Pro Hoops",
                    Quantity = 12,
                    OrderDate = new DateTime(2023, 08, 20),
                    ArticleID = 4
                },
                new Order
                {
                    OrderID = 5,
                    CompanyName = "Tennis Experts",
                    Quantity = 5,
                    OrderDate = new DateTime(2023, 07, 30),
                    ArticleID = 5
                }
            );
        }
    }
}
