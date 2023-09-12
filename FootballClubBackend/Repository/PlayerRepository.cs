using FootballClubBackend.Database;
using FootballClubBackend.Model;

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

        public void Create(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }
    }
}
