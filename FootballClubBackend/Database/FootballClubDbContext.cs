using FootballClubBackend.Model;
using FootballClubBackend.Model.Statistics;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace FootballClubBackend.Database
{
    public class FootballClubDbContext : DbContext
    {
        public FootballClubDbContext(DbContextOptions<FootballClubDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasKey(e => e.Id);
            modelBuilder.Entity<PlayerStatistic>().HasKey(e => e.Id);
        }
    }
}
