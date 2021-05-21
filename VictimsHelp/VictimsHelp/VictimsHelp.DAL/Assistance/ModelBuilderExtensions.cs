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
        }
    }
}
