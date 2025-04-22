using Microsoft.EntityFrameworkCore;
using MvcAppAws_MartinSanchez.Interfaces;
using MvcAppAws_MartinSanchez.Models;

namespace MvcAppAws_MartinSanchez.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Alumno> Alumnos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<Alumno> alumnos = new List<Alumno>() {
                new Alumno {
                    Id = 1,
                    NombreCompleto = "Ana Martínez López",
                    Matricula = "001-INF",
                    Carrera = "Ingeniería Informática",
                    EmpresaAsignada = "TechSolutions",
                    FechaInicio = new DateTime(2025, 1, 15),
                    FechaFin = new DateTime(2025, 6, 15),
                    Estado = IEstadosAlumnos.Activo
                },
                new Alumno {
                    Id = 2,
                    NombreCompleto = "Carlos Ramírez Soto",
                    Matricula = "002-MAT",
                    Carrera = "Matemáticas",
                    EmpresaAsignada = "DataAnalytics MX",
                    FechaInicio = new DateTime(2024, 9, 1),
                    FechaFin = new DateTime(2025, 2, 28),
                    Estado = IEstadosAlumnos.Finalizado
                },
                new Alumno {
                    Id = 3,
                    NombreCompleto = "Lucía Herrera Gómez",
                    Matricula = "003-ADM",
                    Carrera = "Administración",
                    EmpresaAsignada = "Grupo Empresarial del Norte",
                    FechaInicio = new DateTime(2025, 3, 1),
                    FechaFin = new DateTime(2025, 8, 31),
                    Estado = IEstadosAlumnos.Activo
                },
                new Alumno {
                    Id = 4,
                    NombreCompleto = "Miguel Torres Díaz",
                    Matricula = "004-IND",
                    Carrera = "Ingeniería Industrial",
                    EmpresaAsignada = "Industrias Alfa",
                    FechaInicio = new DateTime(2025, 4, 1),
                    FechaFin = new DateTime(2025, 9, 30),
                    Estado = IEstadosAlumnos.Espera
                },
                new Alumno {
                    Id = 5,
                    NombreCompleto = "Sofía Ruiz Vega",
                    Matricula = "005-DER",
                    Carrera = "Derecho",
                    EmpresaAsignada = "Bufete Legal MX",
                    FechaInicio = new DateTime(2024, 10, 1),
                    FechaFin = new DateTime(2025, 3, 31),
                    Estado = IEstadosAlumnos.Finalizado
                },
                new Alumno {
                    Id = 6,
                    NombreCompleto = "Diego Mendoza Pérez",
                    Matricula = "006-MAT",
                    Carrera = "Matemáticas",
                    EmpresaAsignada = "Cálculo Avanzado S.A.",
                    FechaInicio = new DateTime(2025, 2, 1),
                    FechaFin = new DateTime(2025, 7, 31),
                    Estado = IEstadosAlumnos.Activo
                },
                new Alumno {
                    Id = 7,
                    NombreCompleto = "Valeria Jiménez Castro",
                    Matricula = "007-PSI",
                    Carrera = "Psicología",
                    EmpresaAsignada = "Centro Psicológico Integral",
                    FechaInicio = new DateTime(2025, 1, 10),
                    FechaFin = new DateTime(2025, 6, 10),
                    Estado = IEstadosAlumnos.Activo
                },
                new Alumno {
                    Id = 8,
                    NombreCompleto = "Fernando Navarro Gil",
                    Matricula = "008-ARQ",
                    Carrera = "Arquitectura",
                    EmpresaAsignada = "Diseño Urbano MX",
                    FechaInicio = new DateTime(2025, 3, 15),
                    FechaFin = new DateTime(2025, 9, 15),
                    Estado = IEstadosAlumnos.Espera
                },
                new Alumno {
                    Id = 9,
                    NombreCompleto = "Mariana Salas Pineda",
                    Matricula = "009-INF",
                    Carrera = "Ingeniería Informática",
                    EmpresaAsignada = "AppDev Studio",
                    FechaInicio = new DateTime(2024, 9, 1),
                    FechaFin = new DateTime(2025, 2, 28),
                    Estado = IEstadosAlumnos.Finalizado
                },
                new Alumno {
                    Id = 10,
                    NombreCompleto = "José Luis Carrillo Ramos",
                    Matricula = "010-ADM",
                    Carrera = "Administración",
                    EmpresaAsignada = "Consultores Estratégicos",
                    FechaInicio = new DateTime(2025, 1, 20),
                    FechaFin = new DateTime(2025, 6, 20),
                    Estado = IEstadosAlumnos.Activo
                }
            };

            builder.Entity<Alumno>().HasData(alumnos);
        }
    }
}
