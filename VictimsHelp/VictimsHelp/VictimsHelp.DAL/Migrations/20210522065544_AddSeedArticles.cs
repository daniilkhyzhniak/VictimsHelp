using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VictimsHelp.DAL.Migrations
{
    public partial class AddSeedArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("151232d8-cb7e-49a9-8b43-92fa9cce4239"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("9876f97a-f43d-4807-8187-cffe0b17d321"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("a3c333f0-2260-46ea-80fa-f6e9c1b52964"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("b4763038-cd2f-405b-bc13-395255ed5825"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("54226388-fb2b-43d2-aaa8-2081f737256f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("86988951-d8e4-4ccc-86e0-9b08d79329cc"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f7e4589a-5c17-4ed5-b50c-d0bd5e8bb8c5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("317d0585-f49d-44bc-b002-ef2ef824b150"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("340bc179-b3c7-4fdb-8cf2-eec3ab985c6a"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
