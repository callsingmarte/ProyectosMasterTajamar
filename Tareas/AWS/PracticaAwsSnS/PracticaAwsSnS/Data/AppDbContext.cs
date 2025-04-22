using Microsoft.EntityFrameworkCore;
using PracticaAwsSnS.Models;

namespace PracticaAwsSnS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoUsuario> PedidosUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<Pedido> pedidos = new List<Pedido>()
            {
                new Pedido { Id = 1, Nombre = "Caja de 40 tornillos estrella", Cantidad = 1, Precio = 1.60m },
                new Pedido { Id = 2, Nombre = "Destornillador de estrella", Cantidad = 1, Precio = 2.50m },
                new Pedido { Id = 3, Nombre = "Destornillador plano", Cantidad = 1, Precio = 2.50m },
                new Pedido { Id = 4, Nombre = "Martillo", Cantidad = 1, Precio = 3.50m },
                new Pedido { Id = 5, Nombre = "Caja de 40 tornillos planos", Cantidad = 1, Precio = 1.60m },
                new Pedido { Id = 6, Nombre = "Regla de 3 metros", Cantidad = 1, Precio = 3.20m },
                new Pedido { Id = 7, Nombre = "Caja de 20 tacos", Cantidad = 1, Precio = 1.30m }
            };

            builder.Entity<Pedido>().HasData(pedidos);
        }
    }
}
