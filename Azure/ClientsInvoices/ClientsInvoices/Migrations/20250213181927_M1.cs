using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClientsInvoices.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountDue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Dan", "Simmons" },
                    { 2, "Bob", "Builder" },
                    { 3, "Scott", "Markov" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ClientId", "EndDate", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2016, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Entity Framework Project" },
                    { 2, 2, new DateTime(2016, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob's Important Project" },
                    { 3, 3, new DateTime(2016, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some Other Project" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "AmountDue", "DueDate", "ProjectID" },
                values: new object[,]
                {
                    { 1, 34000m, new DateTime(2016, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 50000m, new DateTime(2016, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 2000m, new DateTime(2016, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProjectID",
                table: "Invoices",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
