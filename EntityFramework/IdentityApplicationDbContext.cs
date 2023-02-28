using DataModel.Models.Entity;
using DataModel.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class IdentityApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public IdentityApplicationDbContext(DbContextOptions<IdentityApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserProfile>()
                .HasMany(user => user.Posts)
                .WithOne(post => post.Profile)
                .HasForeignKey(post => post.ProfileId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<UserProfile>()
                .HasMany(user => user.Massages)
                .WithOne(massage => massage.Profile)
                .HasForeignKey(massage => massage.ProfileId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<UserProfile>()
                .HasMany(user => user.OwnerChats)
                .WithOne(chat => chat.Profile)
                .HasForeignKey(chat => chat.ProfileId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<UserProfile>()
                .HasOne(user => user.Club)
                .WithMany(club => club.Members)
                .HasForeignKey(user => user.ClubId)
                .OnDelete(DeleteBehavior.ClientCascade);


            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Host=localhost;Port=5432;Database=IdentityApplicationContext;Username=postgres;Password=123";

            optionsBuilder.UseNpgsql(connectionString, assembly => assembly.MigrationsAssembly("Migrations"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}
