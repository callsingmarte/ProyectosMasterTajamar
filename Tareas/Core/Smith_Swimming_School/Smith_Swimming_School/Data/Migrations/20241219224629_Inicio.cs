using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Smith_Swimming_School.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    Id_Coach = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoachUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.Id_Coach);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id_Grouping = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Places = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id_Grouping);
                });

            migrationBuilder.CreateTable(
                name: "Swimmers",
                columns: table => new
                {
                    Id_Swimmer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SwimmerUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    Birth_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Swimmers", x => x.Id_Swimmer);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id_Course = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Coach = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPlaces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id_Course);
                    table.ForeignKey(
                        name: "FK_Courses_Coaches_Id_Coach",
                        column: x => x.Id_Coach,
                        principalTable: "Coaches",
                        principalColumn: "Id_Coach",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id_Enrollment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Course = table.Column<int>(type: "int", nullable: false),
                    Id_Swimmer = table.Column<int>(type: "int", nullable: true),
                    Id_Grouping = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id_Enrollment);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_Id_Course",
                        column: x => x.Id_Course,
                        principalTable: "Courses",
                        principalColumn: "Id_Course",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Groups_Id_Grouping",
                        column: x => x.Id_Grouping,
                        principalTable: "Groups",
                        principalColumn: "Id_Grouping");
                    table.ForeignKey(
                        name: "FK_Enrollments_Swimmers_Id_Swimmer",
                        column: x => x.Id_Swimmer,
                        principalTable: "Swimmers",
                        principalColumn: "Id_Swimmer");
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id_Report = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgressReport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Enrollment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id_Report);
                    table.ForeignKey(
                        name: "FK_Reports_Enrollments_Id_Enrollment",
                        column: x => x.Id_Enrollment,
                        principalTable: "Enrollments",
                        principalColumn: "Id_Enrollment",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0fae9880-33b1-4ab0-9497-d7bb1fda8746", null, "Administrator", "ADMINISTRATOR" },
                    { "25973d9b-4ec1-4cb9-9b8a-6ab650210cd9", null, "Visitor", "VISITOR" },
                    { "32eaeec6-155f-4309-ba9c-0db45a01c857", null, "Swimmer", "SWIMMER" },
                    { "39942655-b610-46e1-840e-1fbc34fd5317", null, "Coach", "COACH" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "05e475e9-a02f-4241-b274-eeae127c2125", 0, "eb3e1854-0d73-46ae-bba5-6976802ae5e7", "martin.sanchez@gmail.com", true, false, null, "MARTIN.SANCHEZ@GMAIL.COM", "MARTIN.SANCHEZ@GMAIL.COM", "AQAAAAIAAYagAAAAEGOw2RzDkBRucDr99QBd1BibqoihJkp+2nf0pnp4W1geWEV5rchrKUT1t0GFdx22Uw==", "602145318", false, "16bea7ba-4454-429f-8731-5cc55518b218", false, "martin.sanchez@gmail.com" },
                    { "302cd363-98b2-4644-bc6b-b6c7860b1c32", 0, "da06ec36-8711-4779-a240-a467e794874b", "maria.guerrero@gmail.com", true, false, null, "MARIA.GUERRERO@GMAIL.COM", "MARIA.GUERRERO@GMAIL.COM", "AQAAAAIAAYagAAAAEMUYHlck5xgEDTe4kQmO6GCYyKIe8op0EMvkEMUam80ynYDx7XCPZYyeQY3X8CBXcg==", "685214378", false, "dd4c369e-7ada-4575-afed-609e9bc59626", false, "maria.guerrero@gmail.com" },
                    { "3e80a641-a193-4ab9-8310-6e220f2c3b5d", 0, "02d761ec-f37e-4e12-a7f9-2c0058c95ad0", "raul.hernandez@gmail.com", true, false, null, "RAUL.HERNANDEZ@GMAIL.COM", "RAUL.HERNANDEZ@GMAIL.COM", "AQAAAAIAAYagAAAAEK0WoNvLIPnu8eY3O9GHiWeadBOVcvHI1v0ZB2EcVmbW0ThUS9lld3SuBIfwHZ10Gw==", "693251487", false, "825160be-4e17-4ba2-8e18-9f3d9ddb971e", false, "raul.hernandez@gmail.com" },
                    { "5363a831-0116-4509-9e1d-968442431031", 0, "dfa660e9-c96d-4ccd-8934-67ec7ec4aa60", "lucia.sanchiz@gmail.com", true, false, null, "LUCIA.SANCHIZ@GMAIL.COM", "LUCIA.SANCHIZ@GMAIL.COM", "AQAAAAIAAYagAAAAEJg7aWYlQHpdiSJGOGN6WLJty70F083cBrXPiMlS/Q4pa32auhR32dy7YfAoUI9aTQ==", "685214739", false, "570ccada-5d99-458b-8952-3258fbee59fb", false, "lucia.sanchiz@gmail.com" },
                    { "87d800a8-427e-4d6d-b28d-c9e6eb3cbae6", 0, "b1df788a-aa46-49eb-ab4a-e409ea3befd1", "admin@3s.com", true, false, null, "ADMIN@3S.COM", "ADMIN@3S.COM", "AQAAAAIAAYagAAAAEA2YjuQkG7+QoQTQmLsCUHcG8ZNvnVskhj8z/ur3Y8hZAnCwD+uDWza89BrKcw8IWQ==", "653124875", false, "6304fd23-6b1d-471b-8ccb-8a2ef4067ca1", false, "admin@3s.com" },
                    { "b50f0011-ecfa-42de-96b1-2a9f268c9e5f", 0, "704f133e-2cbf-46f4-96d8-6c7156405e0d", "paco.montoro@3s.com", true, false, null, "PACO.MONTORO@3S.COM", "PACO.MONTORO@3S.COM", "AQAAAAIAAYagAAAAEHPAHHR37icx0+C6uKHNA8iqyuyuolMkPojImnociYyKFIIBFa7xweEDQKl4xQ420g==", "632514785", false, "a43b88bb-feda-4eaf-91cc-a716320eb9c0", false, "paco.montoro@3s.com" },
                    { "f1e6d15a-1f1e-4df1-94ce-f28d9abb2ebb", 0, "2645d4df-ec5a-42f1-b68f-38c91f37829f", "marta.alonso@3s.com", true, false, null, "MARTA.ALONSO@3S.COM", "MARTA.ALONSO@3S.COM", "AQAAAAIAAYagAAAAEEl8qd7ZHIdu3KV1MryJy3sKL4qyk8/2NAf30VeEdE6hZR60BXMRO6jd+v5HXXw4iQ==", "632541278", false, "2f07ccb1-0447-45de-ad90-71b3b364d1d9", false, "marta.alonso@3s.com" }
                });

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id_Coach", "CoachUser", "Name", "Phone_Number" },
                values: new object[,]
                {
                    { 1, "paco.montoro@3s.com", "Paco Montoro", "632514785" },
                    { 2, "marta.alonso@3s.com", "Marta Alonso", "632541278" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id_Grouping", "End_Date", "Level", "Name", "Places", "Start_Date" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 31, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, "Young Swimmer fundamentals", 5, new DateTime(2025, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 1, 30, 18, 30, 0, 0, DateTimeKind.Unspecified), 7, "Adult Learning for endurance", 15, new DateTime(2024, 10, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2024, 12, 31, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, "Young Swimmer lv3 fundamentals", 5, new DateTime(2024, 10, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Swimmers",
                columns: new[] { "Id_Swimmer", "Birth_Date", "Genre", "Name", "Phone_Number", "SwimmerUser" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Maria Guerrero", "685214378", "maria.guerrero@gmail.com" },
                    { 2, new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Raul Hernandez", "693251487", "raul.hernandez@gmail.com" },
                    { 3, new DateTime(1995, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Martin Sanchez", "602145318", "martin.sanchez@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "32eaeec6-155f-4309-ba9c-0db45a01c857", "05e475e9-a02f-4241-b274-eeae127c2125" },
                    { "32eaeec6-155f-4309-ba9c-0db45a01c857", "302cd363-98b2-4644-bc6b-b6c7860b1c32" },
                    { "32eaeec6-155f-4309-ba9c-0db45a01c857", "3e80a641-a193-4ab9-8310-6e220f2c3b5d" },
                    { "25973d9b-4ec1-4cb9-9b8a-6ab650210cd9", "5363a831-0116-4509-9e1d-968442431031" },
                    { "0fae9880-33b1-4ab0-9497-d7bb1fda8746", "87d800a8-427e-4d6d-b28d-c9e6eb3cbae6" },
                    { "39942655-b610-46e1-840e-1fbc34fd5317", "b50f0011-ecfa-42de-96b1-2a9f268c9e5f" },
                    { "39942655-b610-46e1-840e-1fbc34fd5317", "f1e6d15a-1f1e-4df1-94ce-f28d9abb2ebb" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id_Course", "Id_Coach", "Title", "TotalPlaces" },
                values: new object[,]
                {
                    { 1, 2, "Swim Training for Endurance", 15 },
                    { 2, 1, "Breaststroke Fundamentals", 10 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id_Enrollment", "Id_Course", "Id_Grouping", "Id_Swimmer" },
                values: new object[,]
                {
                    { 1, 2, 1, 1 },
                    { 2, 1, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id_Report", "Id_Enrollment", "ProgressReport" },
                values: new object[] { 1, 2, "El alumno progresa adecuadamente" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Id_Coach",
                table: "Courses",
                column: "Id_Coach");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_Id_Course",
                table: "Enrollments",
                column: "Id_Course");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_Id_Grouping",
                table: "Enrollments",
                column: "Id_Grouping");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_Id_Swimmer",
                table: "Enrollments",
                column: "Id_Swimmer");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_Id_Enrollment",
                table: "Reports",
                column: "Id_Enrollment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Swimmers");

            migrationBuilder.DropTable(
                name: "Coaches");
        }
    }
}
