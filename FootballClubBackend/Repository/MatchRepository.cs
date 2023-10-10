using FootballClubBackend.Database;
using FootballClubBackend.Model;

namespace FootballClubBackend.Repository
{
    public class MatchRepository
    {
        private readonly FootballClubDbContext _context;

        public MatchRepository(FootballClubDbContext context)
        {
            _context = context;
        }

        public Match Create(Match match)
        {
            var Match = _context.Matches.Add(match).Entity;
            _context.SaveChanges();
            return Match;
        }
    }
}
