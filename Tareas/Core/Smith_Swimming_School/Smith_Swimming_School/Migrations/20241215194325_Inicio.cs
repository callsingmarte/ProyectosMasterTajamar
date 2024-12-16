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
                    CoachId_Coach = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPlaces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id_Course);
                    table.ForeignKey(
                        name: "FK_Courses_Coaches_CoachId_Coach",
                        column: x => x.CoachId_Coach,
                        principalTable: "Coaches",
                        principalColumn: "Id_Coach");
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id_Enrollment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Course = table.Column<int>(type: "int", nullable: false),
                    CourseId_Course = table.Column<int>(type: "int", nullable: true),
                    Id_Swimmer = table.Column<int>(type: "int", nullable: false),
                    SwimmerId_Swimmer = table.Column<int>(type: "int", nullable: true),
                    Id_Grouping = table.Column<int>(type: "int", nullable: false),
                    GroupingId_Grouping = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id_Enrollment);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId_Course",
                        column: x => x.CourseId_Course,
                        principalTable: "Courses",
                        principalColumn: "Id_Course");
                    table.ForeignKey(
                        name: "FK_Enrollments_Groups_GroupingId_Grouping",
                        column: x => x.GroupingId_Grouping,
                        principalTable: "Groups",
                        principalColumn: "Id_Grouping");
                    table.ForeignKey(
                        name: "FK_Enrollments_Swimmers_SwimmerId_Swimmer",
                        column: x => x.SwimmerId_Swimmer,
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
                    Id_Enrollment = table.Column<int>(type: "int", nullable: false),
                    EnrollmentId_Enrollment = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id_Report);
                    table.ForeignKey(
                        name: "FK_Reports_Enrollments_EnrollmentId_Enrollment",
                        column: x => x.EnrollmentId_Enrollment,
                        principalTable: "Enrollments",
                        principalColumn: "Id_Enrollment");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0fa26d6e-6119-4101-b9b7-39f20ad243c6", null, "Coach", "COACH" },
                    { "649dc207-e72b-44a6-bfe6-421345229e7c", null, "Swimmer", "SWIMMER" },
                    { "9903d0e0-a2d4-4166-b493-3cfed45f47e5", null, "Administrator", "ADMINISTRATOR" },
                    { "d5eaa6bb-7b02-4bf5-8ce6-790a294c099b", null, "Visitor", "VISITOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3e68cf35-5091-4e4d-89b9-7f2276754220", 0, "1a9b364e-a4e1-46d1-bb2f-7b77711e1f79", "lucia.sanchiz@gmail.com", true, false, null, "LUCIA.SANCHIZ@GMAIL.COM", "LUCIA.SANCHIZ@GMAIL.COM", "AQAAAAIAAYagAAAAEMx9Refn5g60NoPQEKDfclCLO8Y41rjETwQYmKUrFYUEJBtPtKajRtMnYDA216H+0w==", "685214739", false, "efcc6459-4db4-4259-a3e7-2c3fd114a619", false, "lucia.sanchiz@gmail.com" },
                    { "4860aea5-d244-4409-abd3-0446ddeed21f", 0, "c7f2fe5e-2801-48df-9979-0947a96ec887", "maria.guerrero@gmail.com", true, false, null, "MARIA.GUERRERO@GMAIL.COM", "MARIA.GUERRERO@GMAIL.COM", "AQAAAAIAAYagAAAAEJpMEW4j0HGEkqJkwtMU4jVIiXLPrd/mqNrZu94GPAUUIOIekOJv/5z9w+9925FYfA==", "685214378", false, "05296633-d5f0-43ec-9d4f-f52e44ec1b66", false, "maria.guerrero@gmail.com" },
                    { "8be01698-fef8-4dc2-8c31-c2b6c4e012fd", 0, "0dbfdc20-73dd-487d-af7f-752337adf0c7", "paco.montoro@3s.com", true, false, null, "PACO.MONTORO@3S.COM", "PACO.MONTORO@3S.COM", "AQAAAAIAAYagAAAAEK8wQwdEFuDC0O+DZ8RSmGwwPPeDGZJXKBdHUTiuIhL31+DchN1Zi53tAxi+ZddRPw==", "632514785", false, "83d3d8db-8505-4ac4-89a4-3cc1bd189ee9", false, "paco.montoro@3s.com" },
                    { "aa2d1b3a-818d-4da3-bfe4-de95452c2d98", 0, "c21739b0-248a-4e60-b824-9983f771cfb5", "martin.sanchez@gmail.com", true, false, null, "MARTIN.SANCHEZ@GMAIL.COM", "MARTIN.SANCHEZ@GMAIL.COM", "AQAAAAIAAYagAAAAEMB6DpBhU14yMgMkCcF/jQkJ5BCJ4ei2+wQDhRqrST6F1JVj9MZrTQOfayp4ya0F9w==", "602145318", false, "7ea0200b-a909-4911-a104-ed48d5c60bf7", false, "martin.sanchez@gmail.com" },
                    { "da60d194-a58d-457f-9275-5cc507cc7541", 0, "ba5f7af9-aa64-48dc-9685-c906b172dc85", "admin@3s.com", true, false, null, "ADMIN@3S.COM", "ADMIN@3S.COM", "AQAAAAIAAYagAAAAEGIfpPqHkwJ8p2E7PTyy3TXP/fywmchFi89Q4PQbSLJrCXC56MY9ihWB7CpmsXl8rw==", "653124875", false, "ed22ba1b-0662-4c3c-b2c5-af7d8f4b35d6", false, "admin@3s.com" },
                    { "ecf096ec-367a-4fa3-bdf4-069677b074ba", 0, "4a94adbf-c667-4c74-8443-48c22df77fcc", "raul.hernandez@gmail.com", true, false, null, "RAUL.HERNANDEZ@GMAIL.COM", "RAUL.HERNANDEZ@GMAIL.COM", "AQAAAAIAAYagAAAAEGAWL/uqopwpllc+GnKXuF40AIu57WdVGRWLcbR2ARoiMEsfNgsqGYdjgCVlh8GR8g==", "693251487", false, "80e2f5f0-1165-4ebf-96a1-86fec9642d9f", false, "raul.hernandez@gmail.com" },
                    { "fe47a591-3b43-41ea-9bac-3042e217ed4c", 0, "7f240483-f6f8-425e-ab1b-918990b55960", "marta.alonso@3s.com", true, false, null, "MARTA.ALONSO@3S.COM", "MARTA.ALONSO@3S.COM", "AQAAAAIAAYagAAAAEAP1mczBzBVdda7naEIKPIN1//qKYuIF4FECoyaUdjdxJf9N7CpuxaEYqayxljLfgg==", "632541278", false, "fd4739df-05b3-4be5-9c51-5a8070066250", false, "marta.alonso@3s.com" }
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
                table: "Courses",
                columns: new[] { "Id_Course", "CoachId_Coach", "Id_Coach", "Title", "TotalPlaces" },
                values: new object[,]
                {
                    { 1, null, 2, "Swim Training for Endurance", 15 },
                    { 2, null, 1, "Breaststroke Fundamentals", 10 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id_Enrollment", "CourseId_Course", "GroupingId_Grouping", "Id_Course", "Id_Grouping", "Id_Swimmer", "SwimmerId_Swimmer" },
                values: new object[,]
                {
                    { 1, null, null, 2, 1, 1, null },
                    { 2, null, null, 1, 2, 3, null }
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
                table: "Reports",
                columns: new[] { "Id_Report", "EnrollmentId_Enrollment", "Id_Enrollment", "ProgressReport" },
                values: new object[] { 1, null, 2, "El alumno progresa adecuadamente" });

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
                    { "d5eaa6bb-7b02-4bf5-8ce6-790a294c099b", "3e68cf35-5091-4e4d-89b9-7f2276754220" },
                    { "0fa26d6e-6119-4101-b9b7-39f20ad243c6", "8be01698-fef8-4dc2-8c31-c2b6c4e012fd" },
                    { "9903d0e0-a2d4-4166-b493-3cfed45f47e5", "da60d194-a58d-457f-9275-5cc507cc7541" },
                    { "0fa26d6e-6119-4101-b9b7-39f20ad243c6", "fe47a591-3b43-41ea-9bac-3042e217ed4c" }
                });

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
                name: "IX_Courses_CoachId_Coach",
                table: "Courses",
                column: "CoachId_Coach");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId_Course",
                table: "Enrollments",
                column: "CourseId_Course");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_GroupingId_Grouping",
                table: "Enrollments",
                column: "GroupingId_Grouping");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_SwimmerId_Swimmer",
                table: "Enrollments",
                column: "SwimmerId_Swimmer");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_EnrollmentId_Enrollment",
                table: "Reports",
                column: "EnrollmentId_Enrollment");
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
