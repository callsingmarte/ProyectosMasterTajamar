using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PedidosBlazor.Migrations
{
    /// <inheritdoc />
    public partial class category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Orders",
                newName: "Category");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Category", "Name", "Price" },
                values: new object[] { "Sports Equipment", "Soccer Ball", 25.99m });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Category", "Name", "Price" },
                values: new object[] { "Footwear", "Running Shoes", 80.00m });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Category", "Name", "Price" },
                values: new object[] { "Sports Equipment", "Boxing Gloves", 45.50m });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ID", "Category", "Name", "Price" },
                values: new object[,]
                {
                    { 4, "Sports Equipment", "Basketball", 30.00m },
                    { 5, "Sports Equipment", "Tennis Racket", 120.00m }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1,
                columns: new[] { "Category", "OrderDate", "Quantity" },
                values: new object[] { "Sports World", new DateTime(2023, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2,
                columns: new[] { "Category", "OrderDate", "Quantity" },
                values: new object[] { "Footwear Co.", new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 20 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 3,
                columns: new[] { "Category", "OrderDate", "Quantity" },
                values: new object[] { "Fitness Depot", new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "ArticleID", "Category", "OrderDate", "Quantity" },
                values: new object[,]
                {
                    { 4, 4, "Pro Hoops", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 5, 5, "Tennis Experts", new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Orders",
                newName: "CompanyName");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Category", "Name", "Price" },
                values: new object[] { "Electronics", "Laptop", 1200.00m });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Category", "Name", "Price" },
                values: new object[] { "Electronics", "Smartphone", 800.00m });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Category", "Name", "Price" },
                values: new object[] { "Furniture", "Table", 150.00m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1,
                columns: new[] { "CompanyName", "OrderDate", "Quantity" },
                values: new object[] { "TechCorp", new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2,
                columns: new[] { "CompanyName", "OrderDate", "Quantity" },
                values: new object[] { "GadgetStore", new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 3,
                columns: new[] { "CompanyName", "OrderDate", "Quantity" },
                values: new object[] { "HomeFurnishings", new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 20 });
        }
    }
}
