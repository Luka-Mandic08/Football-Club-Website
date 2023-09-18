using FootballClubBackend.Database;
using FootballClubBackend.Model;
using FootballClubBackend.Model.Statistics;

namespace FootballClubBackend.Repository
{
    public class PlayerStatisticRepository
    {
        private readonly FootballClubDbContext _context;

        public PlayerStatisticRepository(FootballClubDbContext context)
        {
            _context = context;
        }

        public PlayerStatistic GetForPlayerAndYear(Guid id,int year)
        {
            return _context.PlayerStatistics.Where(ps => ps.PlayerId==id && ps.Year == year).First();
        }

        public PlayerStatistic Create(PlayerStatistic playerStatistic)
        {
            var PlayerStatistic = _context.PlayerStatistics.Add(playerStatistic).Entity;
            _context.SaveChanges(); 
            return PlayerStatistic;
        }
    }
}
