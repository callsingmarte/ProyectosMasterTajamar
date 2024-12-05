using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PedidosBlazor.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArticleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Articles_ArticleID",
                        column: x => x.ArticleID,
                        principalTable: "Articles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ID", "Category", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Electronics", "Laptop", 1200.00m },
                    { 2, "Electronics", "Smartphone", 800.00m },
                    { 3, "Furniture", "Table", 150.00m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "ArticleID", "CompanyName", "OrderDate", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "TechCorp", new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 2, 2, "GadgetStore", new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 3, 3, "HomeFurnishings", new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ArticleID",
                table: "Orders",
                column: "ArticleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
