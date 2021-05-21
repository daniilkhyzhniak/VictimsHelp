using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using VictimsHelp.DAL.Entities;

namespace VictimsHelp.DAL.Assistance
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var clientRole = new Role { Id = Guid.NewGuid(), Name = "Client" };
            var adminRole = new Role { Id = Guid.NewGuid(), Name = "Admin" };
            var psychologistRole = new Role { Id = Guid.NewGuid(), Name = "Psychologist" };

            modelBuilder.Entity<Role>().HasData(clientRole, adminRole, psychologistRole);

            var admin = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "admin1",
                LastName = "admin1",
                Email = "admin1@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("admin1@gmail.com"),
                PhoneNumber = "0501234567",
                Gender = "M",
                Age = 25
            };

            var client = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "User1",
                LastName = "User1",
                Email = "user1@gmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("user1@gmail.com"),
                PhoneNumber = "0998887766",
                Gender = "W",
                Age = 20
            };

            modelBuilder.Entity<User>().HasData(admin, client);

            var userRoles = new List<UserRole>
            {
                new UserRole
                {
                    Id = Guid.NewGuid(),
                    UserId = client.Id,
                    RoleId = clientRole.Id
                },
                new UserRole
                {
                    Id = Guid.NewGuid(),
                    UserId = admin.Id,
                    RoleId = adminRole.Id
                },
                new UserRole
                {
                    Id = Guid.NewGuid(),
                    UserId = admin.Id,
                    RoleId = psychologistRole.Id
                },
                new UserRole
                {
                    Id = Guid.NewGuid(),
                    UserId = admin.Id,
                    RoleId = clientRole.Id
                },
            };

            modelBuilder.Entity<UserRole>().HasData(userRoles);

            var article1 = new Article
            {
                Id = Guid.NewGuid(),
                Title = "Addressing Domestic Violence Against Women: An Unfinished Agenda",
                Text = "Domestic violence is a global issue reaching across national" +
                " boundaries as well as socio-economic, cultural, racial and class" +
                " distinctions. This problem is not only widely dispersed geographically," +
                " but its incidence is also extensive, making it a typical and accepted" +
                " behavior. Domestic violence is wide spread, deeply ingrained and has" +
                " serious impacts on women's health and well-being. Its continued existence" +
                " is morally indefensible. Its cost to individuals, to health systems and" +
                " to society is enormous. Yet no other major problem of public health has" +
                " been so widely ignored and so little understood."
            };
            
            var article2 = new Article
            {
                Id = Guid.NewGuid(),
                Title = "What is Domestic Violence?",
                Text = "Domestic violence can be described as the power misused by one adult" +
                " in a relationship to control another. It is the establishment of control" +
                " and fear in a relationship through violence and other forms of abuse." +
                " This violence can take the form of physical assault, psychological abuse," +
                " social abuse, financial abuse, or sexual assault. The frequency of the" +
                " violence can be on and off, occasional or chronic."
            };

            modelBuilder.Entity<Article>().HasData(article1, article2);
        }
    }
}
