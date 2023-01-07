using DataModel.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class IdentityApplicationDbContext : IdentityDbContext<User>
    {
        public IdentityApplicationDbContext(DbContextOptions<IdentityApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.Posts)
                .WithOne(post => post.Author)
                .HasForeignKey(post => post.AuthorId);

            modelBuilder.Entity<User>()
                .HasOne(user => user.Club)
                .WithMany(club => club.Members);

            modelBuilder.Entity<User>()
                .HasMany(user => user.Bets)
                .WithOne(bet => bet.Author)
                .HasForeignKey(bet => bet.AuthorId);

            modelBuilder.Entity<User>()
                .HasMany(user => user.Massages)
                .WithOne(massage => massage.Author)
                .HasForeignKey(massage => massage.AuthorId);

            modelBuilder.Entity<User>()
                .HasMany(user => user.OwnerChats)
                .WithOne(chat => chat.Author)
                .HasForeignKey(chat => chat.AuthorId);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Host=localhost;Port=5432;Database=IdentityApplicationContext;Username=postgres;Password=123";

            optionsBuilder.UseNpgsql(connectionString, assembly => assembly.MigrationsAssembly("Migrations"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}
