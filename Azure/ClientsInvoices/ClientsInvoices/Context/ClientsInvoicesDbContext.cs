using ClientsInvoices.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientsInvoices.Context
{
    public class ClientsInvoicesDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Project> Projects { get; set; }

        public ClientsInvoicesDbContext(DbContextOptions<ClientsInvoicesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, FirstName = "Dan", LastName = "Simmons" },
                new Client { Id = 2, FirstName = "Bob", LastName = "Builder" },
                new Client { Id = 3, FirstName = "Scott", LastName = "Markov" }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    ClientId = 1, 
                    Title = "Entity Framework Project",
                    StartDate = new DateTime(2015, 10, 15),
                    EndDate = new DateTime(2016, 10, 15)
                },
                new Project
                {
                    Id = 2,
                    ClientId = 2, 
                    Title = "Bob's Important Project",
                    StartDate = new DateTime(2015, 10, 15),
                    EndDate = new DateTime(2016, 10, 15)
                },
                new Project
                {
                    Id = 3,
                    ClientId = 3, 
                    Title = "Some Other Project",
                    StartDate = new DateTime(2015, 10, 15),
                    EndDate = new DateTime(2016, 10, 15)
                }
            );

            modelBuilder.Entity<Invoice>().HasData(
                new Invoice
                {
                    Id = 1,
                    AmountDue = 34000m,
                    DueDate = new DateTime(2016, 12, 31),
                    ProjectID = 1
                },
                new Invoice
                {
                    Id = 2,
                    AmountDue = 50000m,
                    DueDate = new DateTime(2016, 12, 31),
                    ProjectID = 2 
                },
                new Invoice
                {
                    Id = 3,
                    AmountDue = 2000m,
                    DueDate = new DateTime(2016, 12, 31),
                    ProjectID = 3 
                }
            );
        }
    }
}
