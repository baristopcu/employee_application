using AuthenticationService.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Data.Context
{
    public class AuthenticationContext : DbContext
    {

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }


        public AuthenticationContext(DbContextOptions<AuthenticationContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles");
            });

        }
    }
}
