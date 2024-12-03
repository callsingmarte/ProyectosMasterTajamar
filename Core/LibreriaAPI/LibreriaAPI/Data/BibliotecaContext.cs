using LibreriaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LibreriaAPI.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options){ }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relacion libro --> Autor
            modelBuilder.Entity<Libro>()
                .HasOne(l => l.Autor)
                .WithMany(a => a.Libros)
                .HasForeignKey(l => l.AutorId);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Libro)
                .WithMany()
                .HasForeignKey(p => p.LibroId);

            modelBuilder.Entity<Autor>().HasData(
                new Autor { Id = 1, Nombre = "Gabriel García Márquez" },
                new Autor { Id = 2, Nombre = "Jane Austen" },
                new Autor { Id = 3, Nombre = "J.K. Rowling" }
            );
            modelBuilder.Entity<Libro>().HasData(
                new Libro { Id = 1, Titulo = "Cien años de soledad", AnioPublicacion = 1967, AutorId = 1 },
                new Libro { Id = 2, Titulo = "Orgullo y prejuicio", AnioPublicacion = 1813, AutorId = 2 },
                new Libro { Id = 3, Titulo = "Harry Potter y la piedra filosofal", AnioPublicacion = 1997, AutorId = 3 }
            );
            modelBuilder.Entity<Prestamo>().HasData(
                new Prestamo
                {
                    Id = 1,
                    LibroId = 1,
                    Usuario = "usuario1@example.com",
                    FechaPrestamo = DateTime.Now.AddDays(-10),
                    FechaDevolucion = DateTime.Now.AddDays(5)
                },
                new Prestamo
                {
                    Id = 2,
                    LibroId = 2,
                    Usuario = "usuario2@example.com",
                    FechaPrestamo = DateTime.Now.AddDays(-20),
                    FechaDevolucion = DateTime.Now.AddDays(-5)
                }
            );
        }
    }
}
