using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPLDataModels;
using Microsoft.EntityFrameworkCore;

namespace IPLDbContext
{
    public class IPLSqlDbContext : DbContext
    {
        public DbSet<Team> teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-NHR5LA7M\\SQLEXPRESS;Initial Catalog=IPLDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>().HasData(
                new Coach
                {
                    Id = 1,
                    Name = "Rushikesh Kotwal",
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new Coach
                {
                    Id = 2,
                    Name = "Punde Pramod",
                    CreatedDate = new DateTime(2025, 1, 2)
                },
                new Coach
                {
                    Id = 3,
                    Name = "Mrunal Rajkar",
                    CreatedDate = new DateTime(2025,1,1)
                });

            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    Id = 1,
                    Name = "LSG",
                    CreatedDate = new DateTime(2025, 1, 1)
                },
                new Team
                {
                    Id = 2,
                    Name = "MI",
                    CreatedDate = new DateTime(2025, 1, 2)
                },
                new Team
                {
                    Id = 3,
                    Name = "RCB",
                    CreatedDate = new DateTime(2025, 1, 1)
                });
            modelBuilder.Entity<Match>().HasData(
                new Match
                {
                    Id = 1,
                    Name = "MI vs CSK",
                    CreatedDate = new DateTime(2025, 3, 23)
                },
                new Match
                {
                    Id = 2,
                    Name = "RCB vs LSG",
                    CreatedDate = new DateTime(2025, 3, 24)
                },
                new Match
                {
                    Id = 3,
                    Name = "DC vs KKR",
                    CreatedDate = new DateTime(2025, 3, 25)
                });

        }
    }
}
