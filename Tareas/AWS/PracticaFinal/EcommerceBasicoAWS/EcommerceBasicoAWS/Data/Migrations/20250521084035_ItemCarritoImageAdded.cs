using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceBasicoAWS.Data.Migrations
{
    /// <inheritdoc />
    public partial class ItemCarritoImageAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "DetallesPedidos",
                keyColumn: "IdDetalle",
                keyValue: new Guid("145a96f0-7c56-4179-9bac-a68b8b3acd8a"));

            migrationBuilder.DeleteData(
                table: "DetallesPedidos",
                keyColumn: "IdDetalle",
                keyValue: new Guid("49816620-f9e8-458e-8f8d-0c083882bce8"));

            migrationBuilder.DeleteData(
                table: "DetallesPedidos",
                keyColumn: "IdDetalle",
                keyValue: new Guid("7591b16b-4484-4f88-99db-1b97a23ee275"));

            migrationBuilder.DeleteData(
                table: "DetallesPedidos",
                keyColumn: "IdDetalle",
                keyValue: new Guid("c424cadc-fb26-4eff-9e48-49d485f18500"));

            migrationBuilder.DeleteData(
                table: "Direcciones",
                keyColumn: "IdDireccion",
                keyValue: new Guid("d7137b33-ff9b-4c8f-a877-c5669fe865c8"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("0ba21c19-63f4-43c2-b3e6-e717ebdd4ce0"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("18ebe6ce-373e-447e-af68-2f131446d7ae"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("4dbf7983-0e9a-4ac7-8624-fad724688299"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("5cb95c59-89bb-49da-b8c8-6237431ea5ce"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("5e76f0eb-82d7-4ee0-a331-1d01bd72b0b5"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("6668d564-1b12-4c1b-94f4-1425bfdb4c72"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("666f3c52-f4d6-4468-91bb-0b5c44137e26"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("7508aee8-2ad3-48c4-9236-5f47ab130653"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("8970662d-45ee-4b9a-9ea9-12e0221105d4"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("9da9811b-74c0-4e30-ab96-bd189b21eeb8"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("9fad02c5-a763-4b6f-8b29-f56ccdee07b5"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("a9f72674-f07d-4a18-9a47-61ec0dbe2a5e"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("b9809c55-ff2e-4139-8e07-3ad16a4ac389"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("c2602fdf-1c21-45ca-9736-cf81dc872f3d"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("dd84b4d7-a157-4946-960a-bca0a0cfee4a"));

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
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("10e95e20-903b-4cc7-b7ae-9298a86ab4e2"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("184aa515-ed4a-4d3b-b198-b77fab6db1d7"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("1bea9180-34ce-46c7-8f10-b48afe6b7609"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("2551e083-97db-4592-a4bc-3b598150382b"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("2a695474-3627-46a4-bf7d-976f2c2bb4c8"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("36a0ab87-61c6-4eb8-b752-5c218fba1f3d"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("54c7b8bd-d646-4be4-bdcf-c5cf11f09083"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("9fa9da00-6885-45c6-96d4-33804713041f"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("ae8a02ec-0ac1-452d-b248-86d332dedf45"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("bece266a-6d03-45c9-ba1b-a7c74d042b95"));

            migrationBuilder.DeleteData(
                table: "Pedidos",
                keyColumn: "IdPedido",
                keyValue: new Guid("240558a7-66ab-49f0-ab30-fc1c69d47384"));

            migrationBuilder.DeleteData(
                table: "Pedidos",
                keyColumn: "IdPedido",
                keyValue: new Guid("974d6a14-4e82-407c-a3c2-bc0ed663dfcc"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("0fd457ad-407e-4cd0-9ea3-80b3b014eb4f"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("1cc7ad5f-1580-48d8-b88e-9f267e563b59"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("3cc06c7c-4b28-48b5-aa7a-3bf78b8b9dea"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("466c5dcf-1cfc-4ee8-ab47-cd3ecefe81c0"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("47c4b2ea-b3b8-4144-a9e5-cb1487d4ef9a"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("6643ce06-d7bc-46f2-bb73-88e70d1c98dd"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("882f3766-47d8-4970-9225-75033be52d8e"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("88c8aaf4-cd86-4781-92e0-af69dc028ea2"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("89e32137-8e16-4ecd-9d59-fb92e6efa3e9"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("f37fc157-c3a7-485a-b9c5-80622300627e"));

            migrationBuilder.DeleteData(
                table: "Direcciones",
                keyColumn: "IdDireccion",
                keyValue: new Guid("a4811600-ad1b-4fe9-b0c4-7d3fab3a8ba9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2001ba6-7581-4a6c-94d3-80b348bca906");

            migrationBuilder.AddColumn<string>(
                name: "MainImageUrl",
                table: "ItemsCarrito",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4eb7fdef-aa3c-473e-94b0-1521fca6475e", null, "Cliente", "CLIENTE" },
                    { "71061cec-029c-4dec-b1f0-24828b683206", null, "Admin", "ADMIN" },
                    { "e256a823-d66c-457c-850e-4c66ea6f9173", null, "Staff", "STAFF" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "51e5f7db-a9cc-4886-95e5-b9a5d5bed5e5", 0, "09eb7659-1c69-4a82-ac6a-7c6fe6a16c86", "lucia.sanchiz@nexusshop.com", true, false, null, "LUCIA.SANCHIZ@NEXUSSHOP.COM", "LUCIA.SANCHIZ@NEXUSSHOP.COM", "AQAAAAIAAYagAAAAEDJq2SZ2kl84o+rEf6KJWDaZFwc/+61zCRDDnmfufPJ+YeTMyVQU2UL5ONcrUVTJSQ==", "685214739", false, "7b36c552-9d84-420b-91c8-35dc39e63e1b", false, "lucia.sanchiz@nexusshop.com" },
                    { "7f6ba682-5e9f-4f59-8805-1f5372d5f35b", 0, "d7c69dc8-0145-475b-b74e-b58dc572355d", "paco.montoro@gmail.com", true, false, null, "PACO.MONTORO@GMAIL.COM", "PACO.MONTORO@GMAIL.COM", "AQAAAAIAAYagAAAAEAdjZZ7LmXCue1xMeaSuAhV1x1uaYiddNlCI0hMCEr+5TpunPoJXVzABo1daDq3uPw==", "632514785", false, "a5a2b3c1-2ffc-434a-b54a-85a11587f185", false, "paco.montoro@gmail.com" },
                    { "d8e55bc7-cccf-4295-8193-44708d9c8710", 0, "40ace187-0738-4a43-bc71-71eb8f5f98c0", "admin@nexusshop.com", true, false, null, "ADMIN@NEXUSSHOP.COM", "ADMIN@NEXUSSHOP.COM", "AQAAAAIAAYagAAAAEDMwTh8JCsdVd530P7JTFUdqrPBtKYBbsVBKjoEQVyYfyMzOH6+rbcffynJDB1sxWA==", "653124875", false, "2c68f4c8-687e-48b1-ad7c-327eb97c7c4f", false, "admin@nexusshop.com" }
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nombre" },
                values: new object[,]
                {
                    { new Guid("0199fb45-4f90-41f9-88f5-823cbecbbfc5"), "Deportes" },
                    { new Guid("1e151a41-ab08-4f66-9c64-c3e95c97af47"), "Tecnología" },
                    { new Guid("24bf372e-8936-4fbf-8d21-81b91e7c9a25"), "Ropa" },
                    { new Guid("4ee9ea41-0b2a-4a42-9637-b143034a590c"), "Accesorios" },
                    { new Guid("82252331-cf7f-4544-8161-d3c33cae4121"), "Belleza" },
                    { new Guid("ba62943f-1480-4bdd-b590-f824b70fc1fe"), "Libros" },
                    { new Guid("bf395ed3-c1e5-4cbc-93f5-d73a880d5774"), "Hogar" },
                    { new Guid("e7e3f7ca-5d40-4d23-8ffa-44a7aea070b8"), "Electrónica" },
                    { new Guid("e98f528d-99cc-4b55-b1d6-eda10ecfc879"), "Joyería" },
                    { new Guid("fd312981-e795-403d-a31d-5a32077c0232"), "Calzado" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "IdProducto", "Descripcion", "FechaActualizacion", "FechaCreacion", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { new Guid("66b287c6-acd0-47e4-b0af-045cde2d6433"), "Taza de cerámica de alta calidad con diseño único.", new DateTime(2025, 5, 21, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5201), new DateTime(2025, 5, 14, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5199), "Taza de Cerámica Decorada", 8.99m, 200 },
                    { new Guid("71bb098c-ee88-4b42-87a6-28058b5687c7"), "Una emocionante novela de fantasía y aventuras.", new DateTime(2025, 5, 21, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5188), new DateTime(2025, 5, 6, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5185), "Libro 'Aventuras Épicas'", 12.50m, 150 },
                    { new Guid("723863c8-1a7e-444b-92c5-a5933f9a7d87"), "Reloj elegante con correa de cuero y movimiento de cuarzo.", new DateTime(2025, 5, 21, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5232), new DateTime(2025, 4, 1, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5230), "Reloj de Pulsera Clásico", 99.99m, 30 },
                    { new Guid("90fa0563-17c1-4779-9fd9-ce313d115060"), "Gafas de sol con lentes polarizadas para una visión clara.", new DateTime(2025, 5, 21, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5149), new DateTime(2025, 5, 1, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5148), "Gafas de Sol Polarizadas", 59.99m, 60 },
                    { new Guid("97bc96e2-dd06-40a0-8c98-c43e18d774c0"), "Auriculares con conexión Bluetooth y sonido de alta fidelidad.", new DateTime(2025, 5, 21, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5238), new DateTime(2025, 4, 26, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5237), "Auriculares Inalámbricos Bluetooth", 69.99m, 80 },
                    { new Guid("a7987e74-9e49-410b-a709-f472f93a298c"), "Bolso de cuero genuino con múltiples compartimentos.", new DateTime(2025, 5, 21, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5144), new DateTime(2025, 2, 20, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5142), "Bolso de Cuero Grande", 129.99m, 20 },
                    { new Guid("b8450b78-cd14-4e65-97ac-3649a55fd9a0"), "Funda resistente para proteger tu teléfono de golpes y arañazos.", new DateTime(2025, 5, 21, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5226), new DateTime(2025, 4, 16, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5204), "Funda Protectora para Smartphone", 24.99m, 120 },
                    { new Guid("c464ef7d-1568-4ac8-8452-2accb5e78be3"), "Pantalón vaquero clásico de corte recto.", new DateTime(2025, 5, 21, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5052), new DateTime(2025, 3, 22, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5050), "Pantalón Vaquero Recto", 49.99m, 50 },
                    { new Guid("cbbe008e-9d5d-4cf4-a4fa-2d2c910c9515"), "Zapatillas cómodas y con estilo para el día a día.", new DateTime(2025, 5, 21, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5129), new DateTime(2025, 4, 6, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5056), "Zapatillas Deportivas Urbanas", 79.99m, 75 },
                    { new Guid("e0009b89-c414-4715-95ad-095fa75dc331"), "Camiseta de manga corta, 100% algodón suave.", new DateTime(2025, 5, 21, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(5043), new DateTime(2025, 4, 21, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(4990), "Camiseta Básica Algodón", 19.99m, 100 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "e256a823-d66c-457c-850e-4c66ea6f9173", "51e5f7db-a9cc-4886-95e5-b9a5d5bed5e5" },
                    { "4eb7fdef-aa3c-473e-94b0-1521fca6475e", "7f6ba682-5e9f-4f59-8805-1f5372d5f35b" },
                    { "71061cec-029c-4dec-b1f0-24828b683206", "d8e55bc7-cccf-4295-8193-44708d9c8710" }
                });

            migrationBuilder.InsertData(
                table: "Direcciones",
                columns: new[] { "IdDireccion", "Ciudad", "CodigoPostal", "Domicilio", "IdUsuario", "Pais", "Provincia", "principal" },
                values: new object[,]
                {
                    { new Guid("ec83090e-331c-4a3e-ac73-48e049b8665a"), "Barcelona", 8001, "Calle de la Piruleta 15", "7f6ba682-5e9f-4f59-8805-1f5372d5f35b", "España", "Barcelona", false },
                    { new Guid("f1f7ea57-94ed-4c28-b16f-80e2e2bb56b9"), "Madrid", 28080, "Avenida Siempreviva 742", "7f6ba682-5e9f-4f59-8805-1f5372d5f35b", "España", "Madrid", true }
                });

            migrationBuilder.InsertData(
                table: "ProductosCategorias",
                columns: new[] { "IdProductoCategoria", "IdCategoria", "IdProducto" },
                values: new object[,]
                {
                    { new Guid("184c4879-5b84-47b4-af27-2c8260f15fd5"), new Guid("24bf372e-8936-4fbf-8d21-81b91e7c9a25"), new Guid("c464ef7d-1568-4ac8-8452-2accb5e78be3") },
                    { new Guid("253cc766-74db-4933-8519-0754937e88e9"), new Guid("e98f528d-99cc-4b55-b1d6-eda10ecfc879"), new Guid("723863c8-1a7e-444b-92c5-a5933f9a7d87") },
                    { new Guid("2d2ffcc2-9dd0-4878-abbe-00e9de78deaa"), new Guid("fd312981-e795-403d-a31d-5a32077c0232"), new Guid("cbbe008e-9d5d-4cf4-a4fa-2d2c910c9515") },
                    { new Guid("516af201-534f-43ed-9b28-6a326a303f10"), new Guid("bf395ed3-c1e5-4cbc-93f5-d73a880d5774"), new Guid("66b287c6-acd0-47e4-b0af-045cde2d6433") },
                    { new Guid("5e077d2e-6a33-4d92-8980-9a8e2e4ff090"), new Guid("4ee9ea41-0b2a-4a42-9637-b143034a590c"), new Guid("90fa0563-17c1-4779-9fd9-ce313d115060") },
                    { new Guid("5e5db5a4-2491-41dd-9da9-464e7b5c5f0c"), new Guid("4ee9ea41-0b2a-4a42-9637-b143034a590c"), new Guid("723863c8-1a7e-444b-92c5-a5933f9a7d87") },
                    { new Guid("6b71d369-9edd-4012-b445-9693b884d7a6"), new Guid("4ee9ea41-0b2a-4a42-9637-b143034a590c"), new Guid("a7987e74-9e49-410b-a709-f472f93a298c") },
                    { new Guid("7f77872d-7275-4edc-8a4e-a879d66e0c73"), new Guid("e7e3f7ca-5d40-4d23-8ffa-44a7aea070b8"), new Guid("b8450b78-cd14-4e65-97ac-3649a55fd9a0") },
                    { new Guid("8325752a-6bd9-4e82-9c16-e59e97c3de6e"), new Guid("1e151a41-ab08-4f66-9c64-c3e95c97af47"), new Guid("b8450b78-cd14-4e65-97ac-3649a55fd9a0") },
                    { new Guid("9974718d-39c2-4f04-9d9e-00019ea6b87f"), new Guid("82252331-cf7f-4544-8161-d3c33cae4121"), new Guid("a7987e74-9e49-410b-a709-f472f93a298c") },
                    { new Guid("c181869f-08a4-4ce2-aa45-9f599536568d"), new Guid("e7e3f7ca-5d40-4d23-8ffa-44a7aea070b8"), new Guid("97bc96e2-dd06-40a0-8c98-c43e18d774c0") },
                    { new Guid("c4487414-5bc0-4f23-8ce3-e7794f1de576"), new Guid("1e151a41-ab08-4f66-9c64-c3e95c97af47"), new Guid("97bc96e2-dd06-40a0-8c98-c43e18d774c0") },
                    { new Guid("ce27ed17-5d11-411e-b0a1-7706adf478ae"), new Guid("24bf372e-8936-4fbf-8d21-81b91e7c9a25"), new Guid("e0009b89-c414-4715-95ad-095fa75dc331") },
                    { new Guid("e5d0b040-f7d0-42c8-8330-42f6fdff3458"), new Guid("0199fb45-4f90-41f9-88f5-823cbecbbfc5"), new Guid("cbbe008e-9d5d-4cf4-a4fa-2d2c910c9515") },
                    { new Guid("eb86f009-daca-4b04-aa88-828ed2c2615b"), new Guid("ba62943f-1480-4bdd-b590-f824b70fc1fe"), new Guid("71bb098c-ee88-4b42-87a6-28058b5687c7") }
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "IdPedido", "Estado", "FechaCreacion", "IdDireccion", "IdUsuario", "Numero", "Total" },
                values: new object[,]
                {
                    { new Guid("0ed5d9ee-359a-4d79-9789-f796996554c0"), "Enviado", new DateTime(2025, 5, 16, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(8446), new Guid("f1f7ea57-94ed-4c28-b16f-80e2e2bb56b9"), "7f6ba682-5e9f-4f59-8805-1f5372d5f35b", 2, 89.50m },
                    { new Guid("25054ab4-7ad3-4c5d-a3d7-d4c8105cc4e3"), "Pendiente", new DateTime(2025, 5, 20, 10, 40, 34, 615, DateTimeKind.Local).AddTicks(8424), new Guid("f1f7ea57-94ed-4c28-b16f-80e2e2bb56b9"), "7f6ba682-5e9f-4f59-8805-1f5372d5f35b", 1, 45.99m }
                });

            migrationBuilder.InsertData(
                table: "DetallesPedidos",
                columns: new[] { "IdDetalle", "Cantidad", "IdPedido", "IdProducto", "PrecioUnitario", "Subtotal" },
                values: new object[,]
                {
                    { new Guid("514677cd-56e8-4d03-ad5f-3513bcee8d0f"), 1, new Guid("0ed5d9ee-359a-4d79-9789-f796996554c0"), new Guid("c464ef7d-1568-4ac8-8452-2accb5e78be3"), 49.99m, 49.99m },
                    { new Guid("b55bfb46-5cb5-4df2-b54d-67ee1ab2dc7d"), 1, new Guid("25054ab4-7ad3-4c5d-a3d7-d4c8105cc4e3"), new Guid("71bb098c-ee88-4b42-87a6-28058b5687c7"), 12.50m, 12.50m },
                    { new Guid("fdac9a7a-f6f2-46f4-8bc5-211bd6762cb0"), 2, new Guid("25054ab4-7ad3-4c5d-a3d7-d4c8105cc4e3"), new Guid("e0009b89-c414-4715-95ad-095fa75dc331"), 19.99m, 39.98m },
                    { new Guid("fdfb1d9e-cc61-4377-b322-f8f15e26e4da"), 1, new Guid("0ed5d9ee-359a-4d79-9789-f796996554c0"), new Guid("97bc96e2-dd06-40a0-8c98-c43e18d774c0"), 69.99m, 69.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e256a823-d66c-457c-850e-4c66ea6f9173", "51e5f7db-a9cc-4886-95e5-b9a5d5bed5e5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4eb7fdef-aa3c-473e-94b0-1521fca6475e", "7f6ba682-5e9f-4f59-8805-1f5372d5f35b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71061cec-029c-4dec-b1f0-24828b683206", "d8e55bc7-cccf-4295-8193-44708d9c8710" });

            migrationBuilder.DeleteData(
                table: "DetallesPedidos",
                keyColumn: "IdDetalle",
                keyValue: new Guid("514677cd-56e8-4d03-ad5f-3513bcee8d0f"));

            migrationBuilder.DeleteData(
                table: "DetallesPedidos",
                keyColumn: "IdDetalle",
                keyValue: new Guid("b55bfb46-5cb5-4df2-b54d-67ee1ab2dc7d"));

            migrationBuilder.DeleteData(
                table: "DetallesPedidos",
                keyColumn: "IdDetalle",
                keyValue: new Guid("fdac9a7a-f6f2-46f4-8bc5-211bd6762cb0"));

            migrationBuilder.DeleteData(
                table: "DetallesPedidos",
                keyColumn: "IdDetalle",
                keyValue: new Guid("fdfb1d9e-cc61-4377-b322-f8f15e26e4da"));

            migrationBuilder.DeleteData(
                table: "Direcciones",
                keyColumn: "IdDireccion",
                keyValue: new Guid("ec83090e-331c-4a3e-ac73-48e049b8665a"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("184c4879-5b84-47b4-af27-2c8260f15fd5"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("253cc766-74db-4933-8519-0754937e88e9"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("2d2ffcc2-9dd0-4878-abbe-00e9de78deaa"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("516af201-534f-43ed-9b28-6a326a303f10"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("5e077d2e-6a33-4d92-8980-9a8e2e4ff090"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("5e5db5a4-2491-41dd-9da9-464e7b5c5f0c"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("6b71d369-9edd-4012-b445-9693b884d7a6"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("7f77872d-7275-4edc-8a4e-a879d66e0c73"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("8325752a-6bd9-4e82-9c16-e59e97c3de6e"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("9974718d-39c2-4f04-9d9e-00019ea6b87f"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("c181869f-08a4-4ce2-aa45-9f599536568d"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("c4487414-5bc0-4f23-8ce3-e7794f1de576"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("ce27ed17-5d11-411e-b0a1-7706adf478ae"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("e5d0b040-f7d0-42c8-8330-42f6fdff3458"));

            migrationBuilder.DeleteData(
                table: "ProductosCategorias",
                keyColumn: "IdProductoCategoria",
                keyValue: new Guid("eb86f009-daca-4b04-aa88-828ed2c2615b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb7fdef-aa3c-473e-94b0-1521fca6475e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71061cec-029c-4dec-b1f0-24828b683206");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e256a823-d66c-457c-850e-4c66ea6f9173");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "51e5f7db-a9cc-4886-95e5-b9a5d5bed5e5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d8e55bc7-cccf-4295-8193-44708d9c8710");

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("0199fb45-4f90-41f9-88f5-823cbecbbfc5"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("1e151a41-ab08-4f66-9c64-c3e95c97af47"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("24bf372e-8936-4fbf-8d21-81b91e7c9a25"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("4ee9ea41-0b2a-4a42-9637-b143034a590c"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("82252331-cf7f-4544-8161-d3c33cae4121"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("ba62943f-1480-4bdd-b590-f824b70fc1fe"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("bf395ed3-c1e5-4cbc-93f5-d73a880d5774"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("e7e3f7ca-5d40-4d23-8ffa-44a7aea070b8"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("e98f528d-99cc-4b55-b1d6-eda10ecfc879"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "IdCategoria",
                keyValue: new Guid("fd312981-e795-403d-a31d-5a32077c0232"));

            migrationBuilder.DeleteData(
                table: "Pedidos",
                keyColumn: "IdPedido",
                keyValue: new Guid("0ed5d9ee-359a-4d79-9789-f796996554c0"));

            migrationBuilder.DeleteData(
                table: "Pedidos",
                keyColumn: "IdPedido",
                keyValue: new Guid("25054ab4-7ad3-4c5d-a3d7-d4c8105cc4e3"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("66b287c6-acd0-47e4-b0af-045cde2d6433"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("71bb098c-ee88-4b42-87a6-28058b5687c7"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("723863c8-1a7e-444b-92c5-a5933f9a7d87"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("90fa0563-17c1-4779-9fd9-ce313d115060"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("97bc96e2-dd06-40a0-8c98-c43e18d774c0"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("a7987e74-9e49-410b-a709-f472f93a298c"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("b8450b78-cd14-4e65-97ac-3649a55fd9a0"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("c464ef7d-1568-4ac8-8452-2accb5e78be3"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("cbbe008e-9d5d-4cf4-a4fa-2d2c910c9515"));

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "IdProducto",
                keyValue: new Guid("e0009b89-c414-4715-95ad-095fa75dc331"));

            migrationBuilder.DeleteData(
                table: "Direcciones",
                keyColumn: "IdDireccion",
                keyValue: new Guid("f1f7ea57-94ed-4c28-b16f-80e2e2bb56b9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7f6ba682-5e9f-4f59-8805-1f5372d5f35b");

            migrationBuilder.DropColumn(
                name: "MainImageUrl",
                table: "ItemsCarrito");

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
        }
    }
}
