using Microsoft.EntityFrameworkCore;
using PracticaAzServiceBus.Models;

namespace PracticaAzServiceBus.Data
{
    public class TransaccionDbContext : DbContext
    {
        public TransaccionDbContext(DbContextOptions<TransaccionDbContext> options) : base(options)
        {            

        }

        DbSet<Transaccion> Transacciones { get; set; }
        DbSet<EventoTransaccion> EventosTransacciones { get; set;}
        DbSet<Notificacion> Notificaciones { get; set; }
    }
}
