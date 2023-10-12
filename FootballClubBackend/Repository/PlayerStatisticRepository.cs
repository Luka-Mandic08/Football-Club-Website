using FootballClubBackend.Model;
using FootballClubBackend.Model.Statistics;
using Microsoft.EntityFrameworkCore;

namespace FootballClubBackend.Repository
{
    public class PlayerStatisticRepository
    {
        /*
        private readonly FootballClubDbContext _context;

        public PlayerStatisticRepository(FootballClubDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PlayerStatistic> GetForPlayerAndYear(Player player,int year)
        {
            var initialQuery = _context.PlayerStatistics;
            if (player.Position == 0)
            {
                var gkQuery = initialQuery.Include(ps => ps.GoalkeepingStatistics);
                return gkQuery.Include(ps => ps.GeneralStatistics).Include(ps => ps.PassingStatistics).Where(ps => ps.PlayerId == player.Id && ps.Year == year).ToList();
            }
            else 
            {
                var partialQuery = initialQuery.Include(ps => ps.DefendingStatistics);
                var outfieldQuery = partialQuery.Include(ps => ps.AttackingStatistics);
                return outfieldQuery.Include(ps => ps.GeneralStatistics).Include(ps => ps.PassingStatistics).Where(ps => ps.PlayerId == player.Id && ps.Year == year).ToList();
            }
        }

        public PlayerStatistic Create(PlayerStatistic playerStatistic)
        {
            var PlayerStatistic = _context.PlayerStatistics.Add(playerStatistic).Entity;
            _context.SaveChanges(); 
            return PlayerStatistic;
        }
        */
    }
}
