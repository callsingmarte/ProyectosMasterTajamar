using Microsoft.EntityFrameworkCore;
using PracticaAwsSnS.Models;

namespace PracticaAwsSnS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
    }
}
