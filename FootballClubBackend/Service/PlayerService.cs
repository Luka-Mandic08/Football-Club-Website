using FootballClubBackend.Model;
using FootballClubBackend.Repository;

namespace FootballClubBackend.Service
{
    public class PlayerService
    {
        private readonly PlayerRepository _playerRepository;

        public PlayerService(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;        
        }

        public IEnumerable<Player> GetAll()
        {
            return _playerRepository.GetAll();
        }

        public void Create(Player player)
        {
            _playerRepository.Create(player);
        }

    }
}
