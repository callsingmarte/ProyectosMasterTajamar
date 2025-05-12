using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceBasicoAWS.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    IdCarrito = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.IdCarrito);
                    table.ForeignKey(
                        name: "FK_Carritos_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    IdDireccion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPostal = table.Column<int>(type: "int", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    principal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.IdDireccion);
                    table.ForeignKey(
                        name: "FK_Direcciones_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    IdProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    IdPedido = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdDireccion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pedidos_Direcciones_IdDireccion",
                        column: x => x.IdDireccion,
                        principalTable: "Direcciones",
                        principalColumn: "IdDireccion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsCarrito",
                columns: table => new
                {
                    IdItemCarrito = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCarrito = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsCarrito", x => x.IdItemCarrito);
                    table.ForeignKey(
                        name: "FK_ItemsCarrito_Carritos_IdCarrito",
                        column: x => x.IdCarrito,
                        principalTable: "Carritos",
                        principalColumn: "IdCarrito",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsCarrito_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultimediaProductos",
                columns: table => new
                {
                    IdMultimedia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreArchivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultimediaProductos", x => x.IdMultimedia);
                    table.ForeignKey(
                        name: "FK_MultimediaProductos_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductosCategorias",
                columns: table => new
                {
                    IdProductoCategoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCategoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosCategorias", x => x.IdProductoCategoria);
                    table.ForeignKey(
                        name: "FK_ProductosCategorias_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosCategorias_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesPedidos",
                columns: table => new
                {
                    IdDetalle = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPedido = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProducto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesPedidos", x => x.IdDetalle);
                    table.ForeignKey(
                        name: "FK_DetallesPedidos_Pedidos_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedidos",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesPedidos_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3721dd9a-2408-4778-91fa-1eb4c12be91f", null, "Admin", "ADMIN" },
                    { "40c93d90-21a0-4af2-8d73-3bc54473bb92", null, "Cliente", "CLIENTE" },
                    { "fe5a2f76-33e9-4660-b8fb-1300d7dcc963", null, "Staff", "STAFF" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "65a989e1-716b-4a5a-8092-228aba53d27b", 0, "2517a2dc-d5bd-40d3-b1d5-5233cce420fb", "paco.montoro@gmail.com", true, false, null, "PACO.MONTORO@GMAIL.COM", "PACO.MONTORO@GMAIL.COM", "AQAAAAIAAYagAAAAEP8LVAUgKwfEkeJ9r8l4iFciEa0J6NOUbUx0kbhxLtpLOglRv+nnGWLq3frjXwlriA==", "632514785", false, "b685be8d-bac6-44f3-bf8a-cc0c1792116a", false, "paco.montoro" },
                    { "9c000a59-685e-455f-af53-28490b148cea", 0, "a07a6e10-a4b6-4c5b-9cf2-3f02779e7db4", "lucia.sanchiz@nexusshop.com", true, false, null, "LUCIA.SANCHIZ@NEXUSSHOP.COM", "LUCIA.SANCHIZ.STAFF", "AQAAAAIAAYagAAAAEBx4RTDf3AwL+z+rXuLWjB9LlujCFbEqbPRew4KeXY73cv7ZAU9CyK0vUpTbHDdivA==", "685214739", false, "63d1a0dc-863f-47d9-b736-7e2234542b77", false, "lucia.sanchiz.staff" },
                    { "d42ec11d-0ec2-424d-bee5-16ae6e05d209", 0, "359fa2ff-1c64-49aa-9d6a-d993487b397d", "admin@nexusshop.com", true, false, null, "ADMIN@NEXUSSHOP.COM", "ADMIN.STAFF", "AQAAAAIAAYagAAAAEA1TbLL/+webcii5IungMOHFim5OFfuBBOcOAKIuVYnJWJ2sjVp6LkSgD2FtxetDhA==", "653124875", false, "7b5b9c28-3d96-4dca-a09a-618280719ee9", false, "admin.staff" }
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nombre" },
                values: new object[,]
                {
                    { new Guid("0bd88478-b979-4d0f-81b7-508f1891a0c2"), "Calzado" },
                    { new Guid("40903fb8-6674-4cfc-b49f-004ad814e15d"), "Libros" },
                    { new Guid("465e17d6-5ad5-4cb1-8000-cd6efa7f9c2e"), "Hogar" },
                    { new Guid("5e1ac5a7-a70e-4f9c-9536-e0cd06cb3636"), "Accesorios" },
                    { new Guid("6975d099-65c4-49cf-bea1-b013b19939f3"), "Joyería" },
                    { new Guid("72062e43-8b0d-46f6-948f-035bf253dd4b"), "Deportes" },
                    { new Guid("8a581e93-829f-43a0-a7aa-5d9614c3f8f3"), "Tecnología" },
                    { new Guid("96264c54-f2e2-4ba2-8c36-4e9e5da36bd2"), "Ropa" },
                    { new Guid("e3c641a7-1cee-41ed-9293-42fb5c13e707"), "Belleza" },
                    { new Guid("f4fd199e-07e2-4b06-9857-5954cf71c500"), "Electrónica" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "IdProducto", "Descripcion", "FechaActualizacion", "FechaCreacion", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { new Guid("0d0d1ec4-28f9-4602-9192-73857bacce94"), "Zapatillas cómodas y con estilo para el día a día.", new DateTime(2025, 5, 12, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2278), new DateTime(2025, 3, 28, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2237), "Zapatillas Deportivas Urbanas", 79.99m, 75 },
                    { new Guid("1311034f-68d5-400f-bf2b-f0821531f556"), "Reloj elegante con correa de cuero y movimiento de cuarzo.", new DateTime(2025, 5, 12, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2407), new DateTime(2025, 3, 23, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2405), "Reloj de Pulsera Clásico", 99.99m, 30 },
                    { new Guid("592d568d-34f8-4e95-90eb-f4b911b0cbaf"), "Camiseta de manga corta, 100% algodón suave.", new DateTime(2025, 5, 12, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2225), new DateTime(2025, 4, 12, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2169), "Camiseta Básica Algodón", 19.99m, 100 },
                    { new Guid("60cd904c-9858-45e7-9ce8-b1a6838628dd"), "Funda resistente para proteger tu teléfono de golpes y arañazos.", new DateTime(2025, 5, 12, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2398), new DateTime(2025, 4, 7, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2374), "Funda Protectora para Smartphone", 24.99m, 120 },
                    { new Guid("74312f93-a549-4781-9d51-f9af37904cd8"), "Gafas de sol con lentes polarizadas para una visión clara.", new DateTime(2025, 5, 12, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2317), new DateTime(2025, 4, 22, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2315), "Gafas de Sol Polarizadas", 59.99m, 60 },
                    { new Guid("86f45a21-2cd3-4bc2-ae90-a66ea2b82a32"), "Pantalón vaquero clásico de corte recto.", new DateTime(2025, 5, 12, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2233), new DateTime(2025, 3, 13, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2231), "Pantalón Vaquero Recto", 49.99m, 50 },
                    { new Guid("8cb0babf-d0ee-4841-a669-03530bb11a99"), "Taza de cerámica de alta calidad con diseño único.", new DateTime(2025, 5, 12, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2370), new DateTime(2025, 5, 5, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2368), "Taza de Cerámica Decorada", 8.99m, 200 },
                    { new Guid("98c8c147-5e36-4909-bbfe-830e44cd06e7"), "Una emocionante novela de fantasía y aventuras.", new DateTime(2025, 5, 12, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2360), new DateTime(2025, 4, 27, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2358), "Libro 'Aventuras Épicas'", 12.50m, 150 },
                    { new Guid("c948f261-7971-4a67-8016-048a39c93380"), "Bolso de cuero genuino con múltiples compartimentos.", new DateTime(2025, 5, 12, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2312), new DateTime(2025, 2, 11, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2310), "Bolso de Cuero Grande", 129.99m, 20 },
                    { new Guid("cad3270c-d626-402d-ab23-5ade37bbb438"), "Auriculares con conexión Bluetooth y sonido de alta fidelidad.", new DateTime(2025, 5, 12, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2414), new DateTime(2025, 4, 17, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(2412), "Auriculares Inalámbricos Bluetooth", 69.99m, 80 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "40c93d90-21a0-4af2-8d73-3bc54473bb92", "65a989e1-716b-4a5a-8092-228aba53d27b" },
                    { "fe5a2f76-33e9-4660-b8fb-1300d7dcc963", "9c000a59-685e-455f-af53-28490b148cea" },
                    { "3721dd9a-2408-4778-91fa-1eb4c12be91f", "d42ec11d-0ec2-424d-bee5-16ae6e05d209" }
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "IdPedido", "Estado", "FechaCreacion", "IdDireccion", "IdUsuario", "Numero", "Total" },
                values: new object[,]
                {
                    { new Guid("245daa81-c409-4438-b7c0-7461116db2ed"), "Enviado", new DateTime(2025, 5, 7, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(5320), new Guid("2512f267-60f1-4605-8c3a-298f1365b06e"), "65a989e1-716b-4a5a-8092-228aba53d27b", 2, 89.50m },
                    { new Guid("93a087d2-59a4-45f4-9bf1-d5db36bbaf52"), "Pendiente", new DateTime(2025, 5, 11, 3, 32, 35, 271, DateTimeKind.Local).AddTicks(5294), new Guid("2512f267-60f1-4605-8c3a-298f1365b06e"), "65a989e1-716b-4a5a-8092-228aba53d27b", 1, 45.99m }
                });

            migrationBuilder.InsertData(
                table: "ProductosCategorias",
                columns: new[] { "IdProductoCategoria", "IdCategoria", "IdProducto" },
                values: new object[,]
                {
                    { new Guid("01c21a67-581d-492a-a287-6bd74dc80bb2"), new Guid("8a581e93-829f-43a0-a7aa-5d9614c3f8f3"), new Guid("60cd904c-9858-45e7-9ce8-b1a6838628dd") },
                    { new Guid("08cbbcc5-3577-4ece-aef2-19cdd0bdc61d"), new Guid("6975d099-65c4-49cf-bea1-b013b19939f3"), new Guid("1311034f-68d5-400f-bf2b-f0821531f556") },
                    { new Guid("1846649b-2a50-4d82-85dd-04b1e21bea90"), new Guid("0bd88478-b979-4d0f-81b7-508f1891a0c2"), new Guid("0d0d1ec4-28f9-4602-9192-73857bacce94") },
                    { new Guid("3ebf3fa3-c209-4b14-b8d9-2f199a8a3355"), new Guid("96264c54-f2e2-4ba2-8c36-4e9e5da36bd2"), new Guid("592d568d-34f8-4e95-90eb-f4b911b0cbaf") },
                    { new Guid("4215d0eb-7390-4585-9dd8-976b79e5004f"), new Guid("5e1ac5a7-a70e-4f9c-9536-e0cd06cb3636"), new Guid("74312f93-a549-4781-9d51-f9af37904cd8") },
                    { new Guid("4f88fb33-f1fa-4ca4-8bc1-a965b68083f7"), new Guid("e3c641a7-1cee-41ed-9293-42fb5c13e707"), new Guid("c948f261-7971-4a67-8016-048a39c93380") },
                    { new Guid("645e5546-f62d-4550-ad7b-484149b0c2f4"), new Guid("465e17d6-5ad5-4cb1-8000-cd6efa7f9c2e"), new Guid("8cb0babf-d0ee-4841-a669-03530bb11a99") },
                    { new Guid("6a65eca3-c241-4dd9-8389-34c17bd0b6b0"), new Guid("40903fb8-6674-4cfc-b49f-004ad814e15d"), new Guid("98c8c147-5e36-4909-bbfe-830e44cd06e7") },
                    { new Guid("7b3e6d10-e20c-48e0-be79-5ac1056ec8d6"), new Guid("f4fd199e-07e2-4b06-9857-5954cf71c500"), new Guid("cad3270c-d626-402d-ab23-5ade37bbb438") },
                    { new Guid("aad50a98-acf1-4e41-a38e-8aec76c8c8d6"), new Guid("96264c54-f2e2-4ba2-8c36-4e9e5da36bd2"), new Guid("86f45a21-2cd3-4bc2-ae90-a66ea2b82a32") },
                    { new Guid("ae17281d-29fd-4b69-8c2a-c50ed88182f6"), new Guid("5e1ac5a7-a70e-4f9c-9536-e0cd06cb3636"), new Guid("c948f261-7971-4a67-8016-048a39c93380") },
                    { new Guid("b2ead4e0-e6c1-44de-888b-dcf84c264ff7"), new Guid("f4fd199e-07e2-4b06-9857-5954cf71c500"), new Guid("60cd904c-9858-45e7-9ce8-b1a6838628dd") },
                    { new Guid("b6f4c035-a3b1-42b2-a9ca-494a1d46d9a5"), new Guid("5e1ac5a7-a70e-4f9c-9536-e0cd06cb3636"), new Guid("1311034f-68d5-400f-bf2b-f0821531f556") },
                    { new Guid("dea84690-512e-435f-a173-f5138dd0c800"), new Guid("8a581e93-829f-43a0-a7aa-5d9614c3f8f3"), new Guid("cad3270c-d626-402d-ab23-5ade37bbb438") },
                    { new Guid("e6ee808b-6b52-4afe-943f-55be3cdaf7ca"), new Guid("72062e43-8b0d-46f6-948f-035bf253dd4b"), new Guid("0d0d1ec4-28f9-4602-9192-73857bacce94") }
                });

            migrationBuilder.InsertData(
                table: "DetallesPedidos",
                columns: new[] { "IdDetalle", "Cantidad", "IdPedido", "IdProducto", "PrecioUnitario", "Subtotal" },
                values: new object[,]
                {
                    { new Guid("3be9c885-4d5d-43cf-9079-28f5206771ae"), 1, new Guid("245daa81-c409-4438-b7c0-7461116db2ed"), new Guid("86f45a21-2cd3-4bc2-ae90-a66ea2b82a32"), 49.99m, 49.99m },
                    { new Guid("91a4a992-75cb-49c0-bf6f-abd89e137298"), 2, new Guid("93a087d2-59a4-45f4-9bf1-d5db36bbaf52"), new Guid("592d568d-34f8-4e95-90eb-f4b911b0cbaf"), 19.99m, 39.98m },
                    { new Guid("9ab541d6-9d44-483d-9fd0-9c56fa72bb21"), 1, new Guid("93a087d2-59a4-45f4-9bf1-d5db36bbaf52"), new Guid("98c8c147-5e36-4909-bbfe-830e44cd06e7"), 12.50m, 12.50m },
                    { new Guid("abb9c7aa-165d-490c-aeae-7d5bcb658797"), 1, new Guid("245daa81-c409-4438-b7c0-7461116db2ed"), new Guid("cad3270c-d626-402d-ab23-5ade37bbb438"), 69.99m, 69.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_IdUsuario",
                table: "Carritos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPedidos_IdPedido",
                table: "DetallesPedidos",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPedidos_IdProducto",
                table: "DetallesPedidos",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_IdUsuario",
                table: "Direcciones",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCarrito_IdCarrito",
                table: "ItemsCarrito",
                column: "IdCarrito");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCarrito_IdProducto",
                table: "ItemsCarrito",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_MultimediaProductos_IdProducto",
                table: "MultimediaProductos",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdDireccion",
                table: "Pedidos",
                column: "IdDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IdUsuario",
                table: "Pedidos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosCategorias_IdCategoria",
                table: "ProductosCategorias",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosCategorias_IdProducto",
                table: "ProductosCategorias",
                column: "IdProducto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesPedidos");

            migrationBuilder.DropTable(
                name: "ItemsCarrito");

            migrationBuilder.DropTable(
                name: "MultimediaProductos");

            migrationBuilder.DropTable(
                name: "ProductosCategorias");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "40c93d90-21a0-4af2-8d73-3bc54473bb92", "65a989e1-716b-4a5a-8092-228aba53d27b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fe5a2f76-33e9-4660-b8fb-1300d7dcc963", "9c000a59-685e-455f-af53-28490b148cea" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3721dd9a-2408-4778-91fa-1eb4c12be91f", "d42ec11d-0ec2-424d-bee5-16ae6e05d209" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3721dd9a-2408-4778-91fa-1eb4c12be91f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40c93d90-21a0-4af2-8d73-3bc54473bb92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe5a2f76-33e9-4660-b8fb-1300d7dcc963");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65a989e1-716b-4a5a-8092-228aba53d27b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c000a59-685e-455f-af53-28490b148cea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d42ec11d-0ec2-424d-bee5-16ae6e05d209");
        }
    }
}
