using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models.Entity;
using DataModel.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Npgsql;

namespace EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Massage> Massages { get; set; }
        public DbSet<Fight> Fights { get; set; }
        public DbSet<Bet> Bets { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(post => post.Comments)
                .WithOne()
                .HasForeignKey<Chat>(chat => chat.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Chat>()
                .HasMany(chat => chat.Massages)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Club>()
                .HasOne(club => club.ChatClub)
                .WithOne()
                .HasForeignKey<Chat>(chat => chat.ClubId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Fight>()
                .HasMany(fight => fight.BetBank)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Host=localhost;Port=5432;Database=ApplicationContext;Username=postgres;Password=123";

            optionsBuilder.UseNpgsql(connectionString, assembly => assembly.MigrationsAssembly("Migrations"));
            
            base.OnConfiguring(optionsBuilder);
        }
    }
}
