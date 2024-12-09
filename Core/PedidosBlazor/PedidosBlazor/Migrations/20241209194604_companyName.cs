using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PedidosBlazor.Migrations
{
    /// <inheritdoc />
    public partial class companyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Orders",
                newName: "CompanyName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Orders",
                newName: "Category");
        }
    }
}
