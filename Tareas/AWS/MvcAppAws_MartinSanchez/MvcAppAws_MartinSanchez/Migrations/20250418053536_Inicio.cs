using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MvcAppAws_MartinSanchez.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carrera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaAsignada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Alumnos",
                columns: new[] { "Id", "Carrera", "EmpresaAsignada", "Estado", "FechaFin", "FechaInicio", "Matricula", "NombreCompleto" },
                values: new object[,]
                {
                    { 1, "Ingeniería Informática", "TechSolutions", "Activo", new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "001-INF", "Ana Martínez López" },
                    { 2, "Matemáticas", "DataAnalytics MX", "Finalizado", new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "002-MAT", "Carlos Ramírez Soto" },
                    { 3, "Administración", "Grupo Empresarial del Norte", "Activo", new DateTime(2025, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "003-ADM", "Lucía Herrera Gómez" },
                    { 4, "Ingeniería Industrial", "Industrias Alfa", "En espera", new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "004-IND", "Miguel Torres Díaz" },
                    { 5, "Derecho", "Bufete Legal MX", "Finalizado", new DateTime(2025, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "005-DER", "Sofía Ruiz Vega" },
                    { 6, "Matemáticas", "Cálculo Avanzado S.A.", "Activo", new DateTime(2025, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "006-MAT", "Diego Mendoza Pérez" },
                    { 7, "Psicología", "Centro Psicológico Integral", "Activo", new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "007-PSI", "Valeria Jiménez Castro" },
                    { 8, "Arquitectura", "Diseño Urbano MX", "En espera", new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "008-ARQ", "Fernando Navarro Gil" },
                    { 9, "Ingeniería Informática", "AppDev Studio", "Finalizado", new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "009-INF", "Mariana Salas Pineda" },
                    { 10, "Administración", "Consultores Estratégicos", "Activo", new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "010-ADM", "José Luis Carrillo Ramos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumnos");
        }
    }
}
