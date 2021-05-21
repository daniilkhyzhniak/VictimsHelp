using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VictimsHelp.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("54226388-fb2b-43d2-aaa8-2081f737256f"), false, "Client" },
                    { new Guid("86988951-d8e4-4ccc-86e0-9b08d79329cc"), false, "Admin" },
                    { new Guid("f7e4589a-5c17-4ed5-b50c-d0bd5e8bb8c5"), false, "Psychologist" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "FirstName", "Gender", "IsDeleted", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("317d0585-f49d-44bc-b002-ef2ef824b150"), 0, "admin1@gmail.com", "admin1", "M", false, "admin1", "$2a$11$mG1qU6KUFnGsVPnniiuyQ.f.7.u0OHubBupDtxxDDijEafoC1Xr3.", "0501234567" },
                    { new Guid("340bc179-b3c7-4fdb-8cf2-eec3ab985c6a"), 0, "user1@gmail.com", "User1", "W", false, "User1", "$2a$11$veTnP4cCgj1fTc05HDB1TOG1zoFltI/CTmeW6esSljklJlsIB0Y52", "0998887766" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "IsDeleted", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("a3c333f0-2260-46ea-80fa-f6e9c1b52964"), false, new Guid("86988951-d8e4-4ccc-86e0-9b08d79329cc"), new Guid("317d0585-f49d-44bc-b002-ef2ef824b150") },
                    { new Guid("151232d8-cb7e-49a9-8b43-92fa9cce4239"), false, new Guid("f7e4589a-5c17-4ed5-b50c-d0bd5e8bb8c5"), new Guid("317d0585-f49d-44bc-b002-ef2ef824b150") },
                    { new Guid("9876f97a-f43d-4807-8187-cffe0b17d321"), false, new Guid("54226388-fb2b-43d2-aaa8-2081f737256f"), new Guid("317d0585-f49d-44bc-b002-ef2ef824b150") },
                    { new Guid("b4763038-cd2f-405b-bc13-395255ed5825"), false, new Guid("54226388-fb2b-43d2-aaa8-2081f737256f"), new Guid("340bc179-b3c7-4fdb-8cf2-eec3ab985c6a") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
