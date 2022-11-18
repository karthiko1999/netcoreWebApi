using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.Migrations
{
    public partial class IntialMigration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    GradeName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Section = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentAddresses",
                columns: table => new
                {
                    StudentAddressId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAddresses", x => x.StudentAddressId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StudentName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GradeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StudentAddressId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_StudentAddresses_StudentAddressId",
                        column: x => x.StudentAddressId,
                        principalTable: "StudentAddresses",
                        principalColumn: "StudentAddressId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users_Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "GradeName", "Section" },
                values: new object[,]
                {
                    { new Guid("51c5dd14-2798-4c9b-8722-31153b6770b7"), "5th Standard", "Asec" },
                    { new Guid("778c4497-c1f5-462c-a4e9-d828edf142c9"), "6th Standard", "Bsec" },
                    { new Guid("7a1a61fa-e271-4e72-baca-f8c5c9c1a53d"), "7th Standard", "Asec" }
                });

            migrationBuilder.InsertData(
                table: "StudentAddresses",
                columns: new[] { "StudentAddressId", "Address", "City", "Country", "State" },
                values: new object[,]
                {
                    { new Guid("644a0074-a67a-4744-884e-e6191f13f1f1"), "2nd Mian 3rd Cross", "Jagalur", "India", "Karnataka" },
                    { new Guid("be497bea-8a87-49a7-9f19-daf62376ffc6"), "3rd Mian 2nd Cross", "Durga", "India", "Karnataka" },
                    { new Guid("f7c18c0f-aa1b-40be-b653-7bbbfd4e4a4b"), " 2nd Cross", "Davangere", "India", "Karnataka" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "DateOfBirth", "GradeId", "StudentAddressId", "StudentName" },
                values: new object[] { new Guid("40de7589-9dcc-4e57-8465-414998a6dcf7"), new DateTime(1999, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("51c5dd14-2798-4c9b-8722-31153b6770b7"), new Guid("be497bea-8a87-49a7-9f19-daf62376ffc6"), "Alex" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "DateOfBirth", "GradeId", "StudentAddressId", "StudentName" },
                values: new object[] { new Guid("973362c8-c169-4387-8c7f-0a25b22326a6"), new DateTime(1999, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("778c4497-c1f5-462c-a4e9-d828edf142c9"), new Guid("be497bea-8a87-49a7-9f19-daf62376ffc6"), "Bob" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "DateOfBirth", "GradeId", "StudentAddressId", "StudentName" },
                values: new object[] { new Guid("ca70207f-d972-4ab1-9cbe-d88d880269b8"), new DateTime(1999, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("7a1a61fa-e271-4e72-baca-f8c5c9c1a53d"), new Guid("f7c18c0f-aa1b-40be-b653-7bbbfd4e4a4b"), "Otto" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GradeId",
                table: "Students",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentAddressId",
                table: "Students",
                column: "StudentAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Roles_RoleId",
                table: "Users_Roles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Roles_UserId",
                table: "Users_Roles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Users_Roles");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "StudentAddresses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
