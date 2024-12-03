using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventosAPI_MartinSanchez.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invitados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Confirmado = table.Column<bool>(type: "bit", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invitados_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Servicio = table.Column<int>(type: "int", nullable: false),
                    Coste = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proveedores_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "Id", "Fecha", "Nombre", "Ubicacion" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), "Boda de Ana y Carlos", "Hacienda Las Flores" },
                    { 2, new DateTime(2024, 4, 20, 19, 30, 0, 0, DateTimeKind.Unspecified), "Concierto de Primavera", "Auditorio Nacional" },
                    { 3, new DateTime(2024, 9, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), "Conferencia de Tecnología", "Centro de Convenciones" },
                    { 4, new DateTime(2024, 12, 31, 21, 0, 0, 0, DateTimeKind.Unspecified), "Fiesta de Fin de Año", "Hotel Gran Lujo" }
                });

            migrationBuilder.InsertData(
                table: "Invitados",
                columns: new[] { "Id", "Confirmado", "Email", "EventoId", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "juan.perez@example.com", 1, "Juan Pérez" },
                    { 2, false, "maria.lopez@example.com", 3, "María López" },
                    { 3, true, "carlos.sanchez@example.com", 2, "Carlos Sánchez" },
                    { 4, false, "ana.martinez@example.com", 2, "Ana Martínez" },
                    { 5, true, "pedro.gomez@example.com", 1, "Pedro Gómez" },
                    { 6, true, "lucia.fernandez@example.com", 3, "Lucía Fernández" },
                    { 7, false, "sofia.diaz@example.com", 3, "Sofía Díaz" },
                    { 8, true, "miguel.rodriguez@example.com", 2, "Miguel Rodríguez" },
                    { 9, false, "elena.jimenez@example.com", 1, "Elena Jiménez" },
                    { 10, true, "javier.torres@example.com", 1, "Javier Torres" }
                });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "Id", "Coste", "EventoId", "Nombre", "Servicio" },
                values: new object[,]
                {
                    { 1, 5000.50m, 3, "Gourmet Catering Co.", 1 },
                    { 2, 3000.75m, 1, "Melodía Viva", 2 },
                    { 3, 2500.30m, 4, "Estilo Floral", 3 },
                    { 4, 4000m, 2, "Evento Perfecto", 4 },
                    { 5, 4500m, 3, "Fiestas Elite", 1 },
                    { 6, 3500m, 2, "Ritmo y Sabor", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invitados_EventoId",
                table: "Invitados",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_EventoId",
                table: "Proveedores",
                column: "EventoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invitados");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
