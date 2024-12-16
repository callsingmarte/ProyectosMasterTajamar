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
                    { "822e8f95-1892-4f87-b0d4-c8d0fce8dbad", null, "Coach", "COACH" },
                    { "97c10d82-6f23-45d8-b507-88b605697185", null, "Administrator", "ADMINISTRATOR" },
                    { "bd8ec400-0f70-47e3-a519-c8b91fa544f5", null, "Visitor", "VISITOR" },
                    { "f0c80341-a483-4f8e-8e0a-8938ebf36b47", null, "Swimmer", "SWIMMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "04b75633-aa57-4d5d-bc37-63eb5b8d6b38", 0, "dfc3908b-5a84-4ec0-9d7f-b38b139521de", "martin.sanchez@gmail.com", true, false, null, "MARTIN.SANCHEZ@GMAIL.COM", "MARTIN.SANCHEZ@GMAIL.COM", "AQAAAAIAAYagAAAAEFLdxaZJScSZjwVYShkMHMmms9Zea1TcjPlZj55Lys+zz+awzSVjlnZUWrJXCc3yhw==", "602145318", false, "fbd3807e-c8f9-4fd6-a9c9-cd2d0591f7a7", false, "martin.sanchez@gmail.com" },
                    { "357d0739-17eb-4db2-988d-ee1a6e50987d", 0, "8d3ef028-50ce-4515-8fc2-a0b251b002f6", "admin@3s.com", true, false, null, "ADMIN@3S.COM", "ADMIN@3S.COM", "AQAAAAIAAYagAAAAEK/shcbWUOaLfkv8xIhYXh2O0MNVVwAtgFAkmp50S4V9w7qCQixUY9LBml8Ty9jx6g==", "653124875", false, "d6c55217-b3f7-44c5-8ec3-238e515d3475", false, "admin@3s.com" },
                    { "56b6dd7e-30be-4593-9437-ee27c0887d4a", 0, "2737113a-2ae6-4541-ad60-3c3cdaf670ab", "raul.hernandez@gmail.com", true, false, null, "RAUL.HERNANDEZ@GMAIL.COM", "RAUL.HERNANDEZ@GMAIL.COM", "AQAAAAIAAYagAAAAEKKqAS/3tFGLb/H9ANiNm2jFBIcnLDdg1lEYMhpYN6rithqoxmqRgjPrmoU0emkROA==", "693251487", false, "6e1cd847-1b09-4397-a1f2-e43c3992a885", false, "raul.hernandez@gmail.com" },
                    { "61433e78-2efb-42ed-a220-22ba8439df70", 0, "5741e054-f254-494b-b1dd-d7f167d4f534", "lucia.sanchiz@gmail.com", true, false, null, "LUCIA.SANCHIZ@GMAIL.COM", "LUCIA.SANCHIZ@GMAIL.COM", "AQAAAAIAAYagAAAAEE+oZqjGJsTjrMTome0w0AywhImMN5ZrU/cqbm5B9aoAZ2SDdSkk3u9ATyaAu098jw==", "685214739", false, "365ad339-4c5c-4016-add7-2124362da625", false, "lucia.sanchiz@gmail.com" },
                    { "c5b85380-b13a-41bc-9d09-33e0257ed25e", 0, "0069eff1-d16e-4ce4-9425-60daa5313b6f", "paco.montoro@3s.com", true, false, null, "PACO.MONTORO@3S.COM", "PACO.MONTORO@3S.COM", "AQAAAAIAAYagAAAAEEnaK7egTQ2qESXvw0Q1420uNSSq8g6QouhccjyLiSLQtZe+W3GBfjSIkQTObtrkTw==", "632514785", false, "1e393a92-2507-4067-94aa-429723bac556", false, "paco.montoro@3s.com" },
                    { "d32ffd42-0478-4e4e-abb8-136150cdb68c", 0, "63b9cc99-d9df-44af-9e0c-ad023f7fa326", "marta.alonso@3s.com", true, false, null, "MARTA.ALONSO@3S.COM", "MARTA.ALONSO@3S.COM", "AQAAAAIAAYagAAAAELey9qFJTh5YXml6d14wg2uhW24RSi+JOSiO2LPOAqjTfuk+zUDvcsCATKVcOYN/yw==", "632541278", false, "fc7caaff-f797-4d90-afce-2c7f85519fe1", false, "marta.alonso@3s.com" },
                    { "ec100f8c-ca2c-4a56-9646-7d0dfc3dfc25", 0, "92fcc023-574f-4f30-bad3-1f7b9d2e380c", "maria.guerrero@gmail.com", true, false, null, "MARIA.GUERRERO@GMAIL.COM", "MARIA.GUERRERO@GMAIL.COM", "AQAAAAIAAYagAAAAEGKjgKOGmtA2pm3sUznUuZDjfVMxJPo0Um8xJs8ACZyvB9NxSw1pa9/RrH2AFgjlyA==", "685214378", false, "24b17937-8517-41f2-8d21-8affe8da3eef", false, "maria.guerrero@gmail.com" }
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
                    { "f0c80341-a483-4f8e-8e0a-8938ebf36b47", "04b75633-aa57-4d5d-bc37-63eb5b8d6b38" },
                    { "97c10d82-6f23-45d8-b507-88b605697185", "357d0739-17eb-4db2-988d-ee1a6e50987d" },
                    { "f0c80341-a483-4f8e-8e0a-8938ebf36b47", "56b6dd7e-30be-4593-9437-ee27c0887d4a" },
                    { "bd8ec400-0f70-47e3-a519-c8b91fa544f5", "61433e78-2efb-42ed-a220-22ba8439df70" },
                    { "822e8f95-1892-4f87-b0d4-c8d0fce8dbad", "c5b85380-b13a-41bc-9d09-33e0257ed25e" },
                    { "822e8f95-1892-4f87-b0d4-c8d0fce8dbad", "d32ffd42-0478-4e4e-abb8-136150cdb68c" },
                    { "f0c80341-a483-4f8e-8e0a-8938ebf36b47", "ec100f8c-ca2c-4a56-9646-7d0dfc3dfc25" }
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
