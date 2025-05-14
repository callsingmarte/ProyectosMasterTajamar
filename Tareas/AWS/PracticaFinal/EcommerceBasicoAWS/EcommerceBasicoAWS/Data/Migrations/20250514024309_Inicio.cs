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
                    Orden = table.Column<int>(type: "int", nullable: false),
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
                    { "04f1b2d1-9af0-40f0-9037-1d0b7136abb0", null, "Cliente", "CLIENTE" },
                    { "9367df67-9205-460a-a177-3b2cd8ff4c2f", null, "Staff", "STAFF" },
                    { "db84f9c5-52cf-4086-90d3-b556212e7bc0", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6b02a11d-e35d-4ba1-8481-a3b83db341dd", 0, "c0c9c656-7b99-4aa5-8c5c-1680533dba18", "lucia.sanchiz@nexusshop.com", true, false, null, "LUCIA.SANCHIZ@NEXUSSHOP.COM", "LUCIA.SANCHIZ.STAFF", "AQAAAAIAAYagAAAAEHxwIHkFkiKyNhLKrq71DLXGAvd0q/uCYdo9tAdRGYeNrWIZIOT6DhqXin1vhKuKig==", "685214739", false, "914cc1d2-e91a-499c-a341-c84bada1cef8", false, "lucia.sanchiz.staff" },
                    { "9c59d061-220a-4cef-b44e-a46e777ab5b7", 0, "9995e88c-4472-425a-96f1-782b7ca3d80c", "admin@nexusshop.com", true, false, null, "ADMIN@NEXUSSHOP.COM", "ADMIN.STAFF", "AQAAAAIAAYagAAAAEFdCOaV39i7WwM+hao3HKM6MiNMKNn7p40jaXoJS9COodfwN/6Pjx1XruJCpbl5hzQ==", "653124875", false, "4c8d7aff-bb35-4b5e-9aec-932b53180051", false, "admin.staff" },
                    { "c2001ba6-7581-4a6c-94d3-80b348bca906", 0, "39129409-b360-4a77-be71-73533f57d78d", "paco.montoro@gmail.com", true, false, null, "PACO.MONTORO@GMAIL.COM", "PACO.MONTORO@GMAIL.COM", "AQAAAAIAAYagAAAAEJVGjCGe3NXRH6E65SUd80ERtwx43BNr+vq0bypDh93Mj9qyLQKzonDvb+BtNNYbPg==", "632514785", false, "7c70ec01-7a01-499d-a067-063a1bd9a94f", false, "paco.montoro" }
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nombre" },
                values: new object[,]
                {
                    { new Guid("10e95e20-903b-4cc7-b7ae-9298a86ab4e2"), "Libros" },
                    { new Guid("184aa515-ed4a-4d3b-b198-b77fab6db1d7"), "Accesorios" },
                    { new Guid("1bea9180-34ce-46c7-8f10-b48afe6b7609"), "Tecnología" },
                    { new Guid("2551e083-97db-4592-a4bc-3b598150382b"), "Deportes" },
                    { new Guid("2a695474-3627-46a4-bf7d-976f2c2bb4c8"), "Calzado" },
                    { new Guid("36a0ab87-61c6-4eb8-b752-5c218fba1f3d"), "Joyería" },
                    { new Guid("54c7b8bd-d646-4be4-bdcf-c5cf11f09083"), "Hogar" },
                    { new Guid("9fa9da00-6885-45c6-96d4-33804713041f"), "Belleza" },
                    { new Guid("ae8a02ec-0ac1-452d-b248-86d332dedf45"), "Electrónica" },
                    { new Guid("bece266a-6d03-45c9-ba1b-a7c74d042b95"), "Ropa" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "IdProducto", "Descripcion", "FechaActualizacion", "FechaCreacion", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { new Guid("0fd457ad-407e-4cd0-9ea3-80b3b014eb4f"), "Pantalón vaquero clásico de corte recto.", new DateTime(2025, 5, 14, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7599), new DateTime(2025, 3, 15, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7597), "Pantalón Vaquero Recto", 49.99m, 50 },
                    { new Guid("1cc7ad5f-1580-48d8-b88e-9f267e563b59"), "Auriculares con conexión Bluetooth y sonido de alta fidelidad.", new DateTime(2025, 5, 14, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7770), new DateTime(2025, 4, 19, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7768), "Auriculares Inalámbricos Bluetooth", 69.99m, 80 },
                    { new Guid("3cc06c7c-4b28-48b5-aa7a-3bf78b8b9dea"), "Zapatillas cómodas y con estilo para el día a día.", new DateTime(2025, 5, 14, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7662), new DateTime(2025, 3, 30, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7603), "Zapatillas Deportivas Urbanas", 79.99m, 75 },
                    { new Guid("466c5dcf-1cfc-4ee8-ab47-cd3ecefe81c0"), "Reloj elegante con correa de cuero y movimiento de cuarzo.", new DateTime(2025, 5, 14, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7763), new DateTime(2025, 3, 25, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7761), "Reloj de Pulsera Clásico", 99.99m, 30 },
                    { new Guid("47c4b2ea-b3b8-4144-a9e5-cb1487d4ef9a"), "Camiseta de manga corta, 100% algodón suave.", new DateTime(2025, 5, 14, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7590), new DateTime(2025, 4, 14, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7528), "Camiseta Básica Algodón", 19.99m, 100 },
                    { new Guid("6643ce06-d7bc-46f2-bb73-88e70d1c98dd"), "Gafas de sol con lentes polarizadas para una visión clara.", new DateTime(2025, 5, 14, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7693), new DateTime(2025, 4, 24, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7691), "Gafas de Sol Polarizadas", 59.99m, 60 },
                    { new Guid("882f3766-47d8-4970-9225-75033be52d8e"), "Una emocionante novela de fantasía y aventuras.", new DateTime(2025, 5, 14, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7719), new DateTime(2025, 4, 29, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7714), "Libro 'Aventuras Épicas'", 12.50m, 150 },
                    { new Guid("88c8aaf4-cd86-4781-92e0-af69dc028ea2"), "Bolso de cuero genuino con múltiples compartimentos.", new DateTime(2025, 5, 14, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7687), new DateTime(2025, 2, 13, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7685), "Bolso de Cuero Grande", 129.99m, 20 },
                    { new Guid("89e32137-8e16-4ecd-9d59-fb92e6efa3e9"), "Funda resistente para proteger tu teléfono de golpes y arañazos.", new DateTime(2025, 5, 14, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7758), new DateTime(2025, 4, 9, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7737), "Funda Protectora para Smartphone", 24.99m, 120 },
                    { new Guid("f37fc157-c3a7-485a-b9c5-80622300627e"), "Taza de cerámica de alta calidad con diseño único.", new DateTime(2025, 5, 14, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7732), new DateTime(2025, 5, 7, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(7730), "Taza de Cerámica Decorada", 8.99m, 200 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9367df67-9205-460a-a177-3b2cd8ff4c2f", "6b02a11d-e35d-4ba1-8481-a3b83db341dd" },
                    { "db84f9c5-52cf-4086-90d3-b556212e7bc0", "9c59d061-220a-4cef-b44e-a46e777ab5b7" },
                    { "04f1b2d1-9af0-40f0-9037-1d0b7136abb0", "c2001ba6-7581-4a6c-94d3-80b348bca906" }
                });

            migrationBuilder.InsertData(
                table: "Direcciones",
                columns: new[] { "IdDireccion", "Ciudad", "CodigoPostal", "Domicilio", "IdUsuario", "Pais", "Provincia", "principal" },
                values: new object[,]
                {
                    { new Guid("a4811600-ad1b-4fe9-b0c4-7d3fab3a8ba9"), "Madrid", 28080, "Avenida Siempreviva 742", "c2001ba6-7581-4a6c-94d3-80b348bca906", "España", "Madrid", true },
                    { new Guid("d7137b33-ff9b-4c8f-a877-c5669fe865c8"), "Barcelona", 8001, "Calle de la Piruleta 15", "c2001ba6-7581-4a6c-94d3-80b348bca906", "España", "Barcelona", false }
                });

            migrationBuilder.InsertData(
                table: "ProductosCategorias",
                columns: new[] { "IdProductoCategoria", "IdCategoria", "IdProducto" },
                values: new object[,]
                {
                    { new Guid("0ba21c19-63f4-43c2-b3e6-e717ebdd4ce0"), new Guid("2551e083-97db-4592-a4bc-3b598150382b"), new Guid("3cc06c7c-4b28-48b5-aa7a-3bf78b8b9dea") },
                    { new Guid("18ebe6ce-373e-447e-af68-2f131446d7ae"), new Guid("184aa515-ed4a-4d3b-b198-b77fab6db1d7"), new Guid("466c5dcf-1cfc-4ee8-ab47-cd3ecefe81c0") },
                    { new Guid("4dbf7983-0e9a-4ac7-8624-fad724688299"), new Guid("1bea9180-34ce-46c7-8f10-b48afe6b7609"), new Guid("89e32137-8e16-4ecd-9d59-fb92e6efa3e9") },
                    { new Guid("5cb95c59-89bb-49da-b8c8-6237431ea5ce"), new Guid("36a0ab87-61c6-4eb8-b752-5c218fba1f3d"), new Guid("466c5dcf-1cfc-4ee8-ab47-cd3ecefe81c0") },
                    { new Guid("5e76f0eb-82d7-4ee0-a331-1d01bd72b0b5"), new Guid("54c7b8bd-d646-4be4-bdcf-c5cf11f09083"), new Guid("f37fc157-c3a7-485a-b9c5-80622300627e") },
                    { new Guid("6668d564-1b12-4c1b-94f4-1425bfdb4c72"), new Guid("ae8a02ec-0ac1-452d-b248-86d332dedf45"), new Guid("89e32137-8e16-4ecd-9d59-fb92e6efa3e9") },
                    { new Guid("666f3c52-f4d6-4468-91bb-0b5c44137e26"), new Guid("10e95e20-903b-4cc7-b7ae-9298a86ab4e2"), new Guid("882f3766-47d8-4970-9225-75033be52d8e") },
                    { new Guid("7508aee8-2ad3-48c4-9236-5f47ab130653"), new Guid("184aa515-ed4a-4d3b-b198-b77fab6db1d7"), new Guid("88c8aaf4-cd86-4781-92e0-af69dc028ea2") },
                    { new Guid("8970662d-45ee-4b9a-9ea9-12e0221105d4"), new Guid("ae8a02ec-0ac1-452d-b248-86d332dedf45"), new Guid("1cc7ad5f-1580-48d8-b88e-9f267e563b59") },
                    { new Guid("9da9811b-74c0-4e30-ab96-bd189b21eeb8"), new Guid("184aa515-ed4a-4d3b-b198-b77fab6db1d7"), new Guid("6643ce06-d7bc-46f2-bb73-88e70d1c98dd") },
                    { new Guid("9fad02c5-a763-4b6f-8b29-f56ccdee07b5"), new Guid("9fa9da00-6885-45c6-96d4-33804713041f"), new Guid("88c8aaf4-cd86-4781-92e0-af69dc028ea2") },
                    { new Guid("a9f72674-f07d-4a18-9a47-61ec0dbe2a5e"), new Guid("2a695474-3627-46a4-bf7d-976f2c2bb4c8"), new Guid("3cc06c7c-4b28-48b5-aa7a-3bf78b8b9dea") },
                    { new Guid("b9809c55-ff2e-4139-8e07-3ad16a4ac389"), new Guid("1bea9180-34ce-46c7-8f10-b48afe6b7609"), new Guid("1cc7ad5f-1580-48d8-b88e-9f267e563b59") },
                    { new Guid("c2602fdf-1c21-45ca-9736-cf81dc872f3d"), new Guid("bece266a-6d03-45c9-ba1b-a7c74d042b95"), new Guid("47c4b2ea-b3b8-4144-a9e5-cb1487d4ef9a") },
                    { new Guid("dd84b4d7-a157-4946-960a-bca0a0cfee4a"), new Guid("bece266a-6d03-45c9-ba1b-a7c74d042b95"), new Guid("0fd457ad-407e-4cd0-9ea3-80b3b014eb4f") }
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "IdPedido", "Estado", "FechaCreacion", "IdDireccion", "IdUsuario", "Numero", "Total" },
                values: new object[,]
                {
                    { new Guid("240558a7-66ab-49f0-ab30-fc1c69d47384"), "Pendiente", new DateTime(2025, 5, 13, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(9894), new Guid("a4811600-ad1b-4fe9-b0c4-7d3fab3a8ba9"), "c2001ba6-7581-4a6c-94d3-80b348bca906", 1, 45.99m },
                    { new Guid("974d6a14-4e82-407c-a3c2-bc0ed663dfcc"), "Enviado", new DateTime(2025, 5, 9, 4, 43, 8, 282, DateTimeKind.Local).AddTicks(9917), new Guid("a4811600-ad1b-4fe9-b0c4-7d3fab3a8ba9"), "c2001ba6-7581-4a6c-94d3-80b348bca906", 2, 89.50m }
                });

            migrationBuilder.InsertData(
                table: "DetallesPedidos",
                columns: new[] { "IdDetalle", "Cantidad", "IdPedido", "IdProducto", "PrecioUnitario", "Subtotal" },
                values: new object[,]
                {
                    { new Guid("145a96f0-7c56-4179-9bac-a68b8b3acd8a"), 1, new Guid("240558a7-66ab-49f0-ab30-fc1c69d47384"), new Guid("882f3766-47d8-4970-9225-75033be52d8e"), 12.50m, 12.50m },
                    { new Guid("49816620-f9e8-458e-8f8d-0c083882bce8"), 1, new Guid("974d6a14-4e82-407c-a3c2-bc0ed663dfcc"), new Guid("1cc7ad5f-1580-48d8-b88e-9f267e563b59"), 69.99m, 69.99m },
                    { new Guid("7591b16b-4484-4f88-99db-1b97a23ee275"), 2, new Guid("240558a7-66ab-49f0-ab30-fc1c69d47384"), new Guid("47c4b2ea-b3b8-4144-a9e5-cb1487d4ef9a"), 19.99m, 39.98m },
                    { new Guid("c424cadc-fb26-4eff-9e48-49d485f18500"), 1, new Guid("974d6a14-4e82-407c-a3c2-bc0ed663dfcc"), new Guid("0fd457ad-407e-4cd0-9ea3-80b3b014eb4f"), 49.99m, 49.99m }
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
                keyValues: new object[] { "9367df67-9205-460a-a177-3b2cd8ff4c2f", "6b02a11d-e35d-4ba1-8481-a3b83db341dd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "db84f9c5-52cf-4086-90d3-b556212e7bc0", "9c59d061-220a-4cef-b44e-a46e777ab5b7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "04f1b2d1-9af0-40f0-9037-1d0b7136abb0", "c2001ba6-7581-4a6c-94d3-80b348bca906" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04f1b2d1-9af0-40f0-9037-1d0b7136abb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9367df67-9205-460a-a177-3b2cd8ff4c2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db84f9c5-52cf-4086-90d3-b556212e7bc0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b02a11d-e35d-4ba1-8481-a3b83db341dd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c59d061-220a-4cef-b44e-a46e777ab5b7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2001ba6-7581-4a6c-94d3-80b348bca906");
        }
    }
}
