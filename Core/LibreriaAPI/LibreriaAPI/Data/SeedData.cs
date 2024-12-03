using LibreriaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibreriaAPI.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider) 
        {
            using var context = new BibliotecaContext(
                    serviceProvider.GetRequiredService<DbContextOptions<BibliotecaContext>>());

            if (context.Libros.Any() || context.Autores.Any() || context.Prestamos.Any())
            {
                return;
            }
            var autores = new List<Autor>
            {
                new Autor { Nombre = "Gabriel García Márquez" },
                new Autor { Nombre = "Jane Austen" },
                new Autor { Nombre = "J.K. Rowling" }
            };
            context.Autores.AddRange(autores);
            context.SaveChanges();

            // Libros iniciales
            var libros = new List<Libro>
            {
                new Libro { Titulo = "Cien años de soledad", AutorId = autores[0].Id, AnioPublicacion = 1967 },
                new Libro { Titulo = "Orgullo y prejuicio", AutorId = autores[1].Id, AnioPublicacion = 1813 },
                new Libro { Titulo = "Harry Potter y la piedra filosofal", AutorId = autores[2].Id, AnioPublicacion = 1997 }
            };

            context.Libros.AddRange(libros);
            context.SaveChanges();
            // Préstamos iniciales
            var prestamos = new List<Prestamo>
            {
                new Prestamo
                {
                    LibroId = libros[0].Id,
                    Usuario = "usuario1@example.com",
                    FechaPrestamo = DateTime.Now.AddDays(-10),
                    FechaDevolucion = DateTime.Now.AddDays(5)
                },
                new Prestamo
                {
                    LibroId = libros[1].Id,
                    Usuario = "usuario2@example.com",
                    FechaPrestamo = DateTime.Now.AddDays(-20),
                    FechaDevolucion = DateTime.Now.AddDays(-5)
                }
            };

            context.Prestamos.AddRange(prestamos);
            context.SaveChanges();
        }
    }
}
