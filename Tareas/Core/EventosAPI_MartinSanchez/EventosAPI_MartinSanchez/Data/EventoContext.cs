using EventosAPI_MartinSanchez.Models;
using Microsoft.EntityFrameworkCore;

namespace EventosAPI_MartinSanchez.Data
{
    public class EventoContext : DbContext
    {
        public EventoContext(DbContextOptions<EventoContext> options) : base(options){ }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Invitado> Invitados { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>().HasData(
                new Evento
                {
                    Id = 1,
                    Nombre = "Boda de Ana y Carlos",
                    Fecha = new DateTime(2024, 6, 15, 17, 0, 0),
                    Ubicacion = "Hacienda Las Flores"
                },
                new Evento
                {
                    Id = 2,
                    Nombre = "Concierto de Primavera",
                    Fecha = new DateTime(2024, 4, 20, 19, 30, 0),
                    Ubicacion = "Auditorio Nacional"
                },
                new Evento
                {
                    Id = 3,
                    Nombre = "Conferencia de Tecnología",
                    Fecha = new DateTime(2024, 9, 10, 9, 0, 0),
                    Ubicacion = "Centro de Convenciones"
                },
                new Evento
                {
                    Id = 4,
                    Nombre = "Fiesta de Fin de Año",
                    Fecha = new DateTime(2024, 12, 31, 21, 0, 0),
                    Ubicacion = "Hotel Gran Lujo"
                }
            );
            modelBuilder.Entity<Invitado>().HasData(
                new Invitado
                {
                    Id = 1,
                    Nombre = "Juan Pérez",
                    Email = "juan.perez@example.com",
                    Confirmado = true,
                    EventoId = 1
                },
                new Invitado
                {
                    Id = 2,
                    Nombre = "María López",
                    Email = "maria.lopez@example.com",
                    Confirmado = false,
                    EventoId = 3
                },
                new Invitado
                {
                    Id = 3,
                    Nombre = "Carlos Sánchez",
                    Email = "carlos.sanchez@example.com",
                    Confirmado = true,
                    EventoId = 2
                },
                new Invitado
                {
                    Id = 4,
                    Nombre = "Ana Martínez",
                    Email = "ana.martinez@example.com",
                    Confirmado = false,
                    EventoId = 2
                },
                new Invitado
                {
                    Id = 5,
                    Nombre = "Pedro Gómez",
                    Email = "pedro.gomez@example.com",
                    Confirmado = true,
                    EventoId = 1
                },
                new Invitado
                {
                    Id = 6,
                    Nombre = "Lucía Fernández",
                    Email = "lucia.fernandez@example.com",
                    Confirmado = true,
                    EventoId = 3
                },
                new Invitado
                {
                    Id = 7,
                    Nombre = "Sofía Díaz",
                    Email = "sofia.diaz@example.com",
                    Confirmado = false,
                    EventoId = 3
                },
                new Invitado
                {
                    Id = 8,
                    Nombre = "Miguel Rodríguez",
                    Email = "miguel.rodriguez@example.com",
                    Confirmado = true,
                    EventoId = 2
                },
                new Invitado
                {
                    Id = 9,
                    Nombre = "Elena Jiménez",
                    Email = "elena.jimenez@example.com",
                    Confirmado = false,
                    EventoId = 1
                },
                new Invitado
                {
                    Id = 10,
                    Nombre = "Javier Torres",
                    Email = "javier.torres@example.com",
                    Confirmado = true,
                    EventoId = 1
                }
            );
            modelBuilder.Entity<Proveedor>().HasData(
                new Proveedor
                {
                    Id = 1,
                    Nombre = "Gourmet Catering Co.",
                    Servicio = Servicio.Catering,
                    Coste = 5000.50m,
                    EventoId = 3,
                },
                new Proveedor
                {
                    Id = 2,
                    Nombre = "Melodía Viva",
                    Servicio = Servicio.Musica,
                    Coste = 3000.75m,
                    EventoId = 1,
                },
                new Proveedor
                {
                    Id = 3,
                    Nombre = "Estilo Floral",
                    Servicio = Servicio.Decoracion,
                    Coste = 2500.30m,
                    EventoId = 4,
                },
                new Proveedor
                {
                    Id = 4,
                    Nombre = "Evento Perfecto",
                    Servicio = Servicio.Otro,
                    Coste = 4000m,
                    EventoId = 2,
                },
                new Proveedor
                {
                    Id = 5,
                    Nombre = "Fiestas Elite",
                    Servicio = Servicio.Catering,
                    Coste = 4500m,
                    EventoId = 3,
                },
                new Proveedor
                {
                    Id = 6,
                    Nombre = "Ritmo y Sabor",
                    Servicio = Servicio.Musica,
                    Coste = 3500m,
                    EventoId = 2,
                }
            );
        }
    }
}
