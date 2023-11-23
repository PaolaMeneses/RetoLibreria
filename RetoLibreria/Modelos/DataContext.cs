using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace RetoLibreria.Modelos
{

    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Resena> Resenas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>()
            .HasKey(u => u.Id);

            modelBuilder.Entity<IdentityRole>()
            .HasKey(r => r.Id);

            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasKey(r => new { r.UserId, r.RoleId });

            modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasKey(l => new { l.LoginProvider, l.ProviderKey });

            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<User>()
                  .HasMany(u => u.Books)
                  .WithOne(b => b.User)

              .OnDelete(DeleteBehavior.Cascade);

                 modelBuilder.Entity<Book>()
                 .HasOne(b => b.User)
                 .WithMany(u => u.Books)
                 .OnDelete(DeleteBehavior.Cascade);

            }
        }
        




       }


}

   

