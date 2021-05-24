using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VictimsHelp.DAL.Migrations
{
    public partial class AddMessageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("72fe5af5-2a2f-4292-90c0-03aed8671ff0"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("a46e9e97-bc93-4d7e-b67c-7f5fec9f98ad"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("0923a1ca-5d99-4033-b7ab-78aa343cbdb1"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("23bf8b53-499d-40e8-abe9-015805bc4a8c"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa51efc0-c6d9-4936-90da-4df3fd59f157"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("cb3f7525-5458-412c-9cfd-23b21d336131"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("27888873-b852-44d2-a482-64d7c6d85d94"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5ab6bdcc-5837-4c98-9206-0354c9cb6ddb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8a12aa32-0dfe-437e-b096-1d47b4d6bdda"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38ed52ad-0772-4ab2-905b-a4af5a7a6e35"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5b554bee-ce23-4f1d-8677-00389ac2505c"));

            migrationBuilder.AddColumn<string>(
                name: "PsychologistEmail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PsychologistId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiverEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "IsDeleted", "Text", "Title" },
                values: new object[,]
                {
                    { new Guid("3ab5e3ec-ba2e-44a3-96fb-541d53ba159b"), false, "Domestic violence is a global issue reaching across national boundaries as well as socio-economic, cultural, racial and class distinctions. This problem is not only widely dispersed geographically, but its incidence is also extensive, making it a typical and accepted behavior. Domestic violence is wide spread, deeply ingrained and has serious impacts on women's health and well-being. Its continued existence is morally indefensible. Its cost to individuals, to health systems and to society is enormous. Yet no other major problem of public health has been so widely ignored and so little understood.", "Addressing Domestic Violence Against Women: An Unfinished Agenda" },
                    { new Guid("9ac64c34-d62d-40ce-babc-161654a03756"), false, "Domestic violence can be described as the power misused by one adult in a relationship to control another. It is the establishment of control and fear in a relationship through violence and other forms of abuse. This violence can take the form of physical assault, psychological abuse, social abuse, financial abuse, or sexual assault. The frequency of the violence can be on and off, occasional or chronic.", "What is Domestic Violence?" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("64a967c4-0caf-4e34-9697-fcd428629916"), false, "Client" },
                    { new Guid("3c1c8a71-9110-4258-858b-ed5d6855fd38"), false, "Admin" },
                    { new Guid("500baaa9-3826-4c82-aa06-c1b827676bd3"), false, "Psychologist" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "FirstName", "Gender", "IsDeleted", "LastName", "Password", "PhoneNumber", "PsychologistEmail", "PsychologistId" },
                values: new object[,]
                {
                    { new Guid("a7979a3c-2e0d-40b5-ad52-ca21469336f3"), 25, "admin1@gmail.com", "admin1", "M", false, "admin1", "$2a$11$A1.DAG8c68avBpLs3MgAwefKw.HBhV5NksdXLshxgnAHaoxEGpgy.", "0501234567", null, null },
                    { new Guid("8d703abc-cde4-4338-8dae-6c30f1d9efd9"), 20, "user1@gmail.com", "User1", "W", false, "User1", "$2a$11$5VYh3St65BRLBwRCYrVEie0FNylQ7Uvb.WjEM13WOh/KXyh.rSOqC", "0998887766", "user2@gmail.com", null },
                    { new Guid("dd2a504d-a40b-407e-b5e4-c15dea155dd9"), 25, "user2@gmail.com", "Psychologist", "M", false, "Psychologist", "$2a$11$k0qrKDsOOobvmvSCgVbFAuxuI2GDGc0fX32c3KuZ7DHZrcGIAKpku", "0501234567", null, null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "IsDeleted", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("be9eee3b-7a25-4d3f-827b-eb44d86b72db"), false, new Guid("3c1c8a71-9110-4258-858b-ed5d6855fd38"), new Guid("a7979a3c-2e0d-40b5-ad52-ca21469336f3") },
                    { new Guid("0e2569f8-ebac-4587-9cc2-ec814e278aee"), false, new Guid("500baaa9-3826-4c82-aa06-c1b827676bd3"), new Guid("a7979a3c-2e0d-40b5-ad52-ca21469336f3") },
                    { new Guid("e7b6e5c6-f601-4e82-8dab-55476e31b153"), false, new Guid("64a967c4-0caf-4e34-9697-fcd428629916"), new Guid("a7979a3c-2e0d-40b5-ad52-ca21469336f3") },
                    { new Guid("7f17f0e8-7c1a-4edb-ba04-fd0342107616"), false, new Guid("64a967c4-0caf-4e34-9697-fcd428629916"), new Guid("8d703abc-cde4-4338-8dae-6c30f1d9efd9") },
                    { new Guid("f4fb3d5c-ce85-4bdb-a233-c58ac165ee5b"), false, new Guid("500baaa9-3826-4c82-aa06-c1b827676bd3"), new Guid("dd2a504d-a40b-407e-b5e4-c15dea155dd9") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PsychologistId",
                table: "Users",
                column: "PsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_PsychologistId",
                table: "Users",
                column: "PsychologistId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_PsychologistId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Users_PsychologistId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("3ab5e3ec-ba2e-44a3-96fb-541d53ba159b"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("9ac64c34-d62d-40ce-babc-161654a03756"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e2569f8-ebac-4587-9cc2-ec814e278aee"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f17f0e8-7c1a-4edb-ba04-fd0342107616"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("be9eee3b-7a25-4d3f-827b-eb44d86b72db"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("e7b6e5c6-f601-4e82-8dab-55476e31b153"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("f4fb3d5c-ce85-4bdb-a233-c58ac165ee5b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3c1c8a71-9110-4258-858b-ed5d6855fd38"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("500baaa9-3826-4c82-aa06-c1b827676bd3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("64a967c4-0caf-4e34-9697-fcd428629916"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8d703abc-cde4-4338-8dae-6c30f1d9efd9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a7979a3c-2e0d-40b5-ad52-ca21469336f3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dd2a504d-a40b-407e-b5e4-c15dea155dd9"));

            migrationBuilder.DropColumn(
                name: "PsychologistEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PsychologistId",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "IsDeleted", "Text", "Title" },
                values: new object[,]
                {
                    { new Guid("72fe5af5-2a2f-4292-90c0-03aed8671ff0"), false, "Domestic violence is a global issue reaching across national boundaries as well as socio-economic, cultural, racial and class distinctions. This problem is not only widely dispersed geographically, but its incidence is also extensive, making it a typical and accepted behavior. Domestic violence is wide spread, deeply ingrained and has serious impacts on women's health and well-being. Its continued existence is morally indefensible. Its cost to individuals, to health systems and to society is enormous. Yet no other major problem of public health has been so widely ignored and so little understood.", "Addressing Domestic Violence Against Women: An Unfinished Agenda" },
                    { new Guid("a46e9e97-bc93-4d7e-b67c-7f5fec9f98ad"), false, "Domestic violence can be described as the power misused by one adult in a relationship to control another. It is the establishment of control and fear in a relationship through violence and other forms of abuse. This violence can take the form of physical assault, psychological abuse, social abuse, financial abuse, or sexual assault. The frequency of the violence can be on and off, occasional or chronic.", "What is Domestic Violence?" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("27888873-b852-44d2-a482-64d7c6d85d94"), false, "Client" },
                    { new Guid("8a12aa32-0dfe-437e-b096-1d47b4d6bdda"), false, "Admin" },
                    { new Guid("5ab6bdcc-5837-4c98-9206-0354c9cb6ddb"), false, "Psychologist" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "FirstName", "Gender", "IsDeleted", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("38ed52ad-0772-4ab2-905b-a4af5a7a6e35"), 25, "admin1@gmail.com", "admin1", "M", false, "admin1", "$2a$11$emHTHcWlycIyWmKscbHMYeLJeE2ElPBQdngHsSoc7kpyvrL.OKdvu", "0501234567" },
                    { new Guid("5b554bee-ce23-4f1d-8677-00389ac2505c"), 20, "user1@gmail.com", "User1", "W", false, "User1", "$2a$11$us4WkCKScIRQRGUonh83FuHWdHNJkFiXPaOu98CcDxauj5Y01kTde", "0998887766" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "IsDeleted", "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("aa51efc0-c6d9-4936-90da-4df3fd59f157"), false, new Guid("8a12aa32-0dfe-437e-b096-1d47b4d6bdda"), new Guid("38ed52ad-0772-4ab2-905b-a4af5a7a6e35") },
                    { new Guid("23bf8b53-499d-40e8-abe9-015805bc4a8c"), false, new Guid("5ab6bdcc-5837-4c98-9206-0354c9cb6ddb"), new Guid("38ed52ad-0772-4ab2-905b-a4af5a7a6e35") },
                    { new Guid("0923a1ca-5d99-4033-b7ab-78aa343cbdb1"), false, new Guid("27888873-b852-44d2-a482-64d7c6d85d94"), new Guid("38ed52ad-0772-4ab2-905b-a4af5a7a6e35") },
                    { new Guid("cb3f7525-5458-412c-9cfd-23b21d336131"), false, new Guid("27888873-b852-44d2-a482-64d7c6d85d94"), new Guid("5b554bee-ce23-4f1d-8677-00389ac2505c") }
                });
        }
    }
}
