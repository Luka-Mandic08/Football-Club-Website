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

        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchEvent> MatchEvents { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>().HasMany(m => m.MatchEvents).WithOne(e => e.Match);
            modelBuilder.Entity<Match>().HasMany(m => m.SquadStatistics);
            modelBuilder.Entity<Match>().HasMany(m => m.OpponentSquadStatistics);
        }
    }
}
