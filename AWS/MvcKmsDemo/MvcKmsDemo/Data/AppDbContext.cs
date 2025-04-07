using Microsoft.EntityFrameworkCore;
using MvcKmsDemo.Models;

namespace MvcKmsDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Message> Messages => Set<Message>();

    }
}
