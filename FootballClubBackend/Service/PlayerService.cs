using FootballClubBackend.Model;
using FootballClubBackend.Model.Statistics;
using FootballClubBackend.Repository;

namespace FootballClubBackend.Service
{
    public class PlayerService
    {
        private readonly PlayerRepository _playerRepository;
        private readonly PlayerStatisticRepository _playerStatisticRepository;

        public PlayerService(PlayerRepository playerRepository, PlayerStatisticRepository playerStatisticRepository)
        {
            _playerRepository = playerRepository;
            _playerStatisticRepository = playerStatisticRepository;
        }

        public IEnumerable<Player> GetAll()
        {
            return _playerRepository.GetAll();
        }

        public bool Create(Player player, string[] competitions)
        {
            if (!_playerRepository.CheckSquadNumberAvailability(player.SquadNumber, player.Team))
            {
                return false;
            }
            Player playerWithId = _playerRepository.Create(player);
            foreach (var competition in competitions)
            {
                PlayerStatistic playerStatistic = new PlayerStatistic(GetYearForNewPlayer(), competition,playerWithId.Id,player.Position == 0);
                _playerStatisticRepository.Create(playerStatistic);
            }
            return true;
        }

        public Player? GetById(String id)
        {
            try
            { 
                Guid guid = Guid.Parse(id);
                return _playerRepository.GetById(guid);
            }
            
            catch (Exception)
            {
                return null;
            }
            
        }

        public int GetYearForNewPlayer()
        {
            DateTime currentDate = DateTime.Today;
            if (currentDate.Month >= 7) {
                return currentDate.Year;
            }
            return currentDate.Year - 1;
        }

    }
}
