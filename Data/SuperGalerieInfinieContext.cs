using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperGalerieInfinie.Models;

namespace SuperGalerieInfinie.Data
{
    public class SuperGalerieInfinieContext : IdentityDbContext<User>
    {
        public SuperGalerieInfinieContext(DbContextOptions<SuperGalerieInfinieContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            User u1 = new User
            {
                Id = "11111111-1111-1111-1111-111111111111", // Format GUID ! 
                UserName = "sam",
                Email = "samsam@gmail.com",
                NormalizedEmail = "SAMSAM@GMAIL.COM",
                NormalizedUserName = "SAM"
            };
            u1.PasswordHash = hasher.HashPassword(u1, "Salut1!");
            User u2 = new User
            {
                Id = "11111111-1111-1111-1111-111111111112", // Format GUID ! 
                UserName = "max",
                Email = "maxmax@gmail.com",
                NormalizedEmail = "MAXMAX@GMAIL.COM",
                NormalizedUserName = "MAX"
            };
            u2.PasswordHash = hasher.HashPassword(u2, "Salut1!");
            builder.Entity<User>().HasData(u1,u2);
            builder.Entity<Galerie>().HasData(
                new { Id = 1, Name="galeriePUBLIC", Publique = true},
                new { Id = 2, Name = "galeriePRIVE", Publique = false }
            );
            builder.Entity<Galerie>()
                .HasMany(u => u.Utilisateurs)
                .WithMany(g => g.Galeries)
                .UsingEntity(e => {
                    e.HasData(new { UtilisateursId = u1.Id, GaleriesId = 1 });
                    e.HasData(new { UtilisateursId = u1.Id, GaleriesId = 2 });
                    e.HasData(new { UtilisateursId = u2.Id, GaleriesId = 1 });
                    e.HasData(new { UtilisateursId = u2.Id, GaleriesId = 2 });
                });
        }

        public DbSet<Galerie> Galeries { get; set; } = default!;
    }
}
