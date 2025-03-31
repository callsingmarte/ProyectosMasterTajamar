using Microsoft.EntityFrameworkCore;
using PracticaAzServiceBus.Models;

namespace PracticaAzServiceBus.Data
{
    public class TransaccionDbContext : DbContext
    {
        public TransaccionDbContext(DbContextOptions<TransaccionDbContext> options) : base(options)
        {            

        }

        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<EventoTransaccion> EventosTransacciones { get; set;}
        public DbSet<Notificacion> Notificaciones { get; set; }
    }
}
