using FootballClubBackend.Database;
using FootballClubBackend.Model;
using FootballClubBackend.Model.Enums;

namespace FootballClubBackend.Repository
{
    public class PlayerRepository
    {
        private readonly FootballClubDbContext _context;

        public PlayerRepository(FootballClubDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Player> GetAll()
        {
            return _context.Players.ToList();
        }

        public Player Create(Player player)
        {
            var Player = _context.Players.Add(player).Entity;
            _context.SaveChanges();
            return Player;
        }

        public bool CheckSquadNumberAvailability(int squadNumber, Team team)
        {
            return !_context.Players.Any(p => p.SquadNumber == squadNumber && p.Team == team && (int)p.Status != 1);
        }

        public Player GetById(Guid id)
        {
            return _context.Players.Where(p => p.Id == id).First();
        }
    }
}
