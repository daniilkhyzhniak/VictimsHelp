using Microsoft.EntityFrameworkCore;
using VictimsHelp.DAL.Assistance;
using VictimsHelp.DAL.Entities;

namespace VictimsHelp.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Messages)
                .WithOne(m => m.Sender);

            modelBuilder.Entity<User>()
                .HasIndex(g => g.Email)
                .IsUnique();

            modelBuilder.Entity<Role>()
                .HasIndex(g => g.Name)
                .IsUnique();

            modelBuilder.Seed();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
