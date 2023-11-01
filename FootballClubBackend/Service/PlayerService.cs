using FootballClubBackend.Model;
using FootballClubBackend.Model.DTO;
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

        public bool Create(Player player)
        {
            if (_playerRepository.CheckSquadNumberAvailability(player.SquadNumber))
            {
                return false;
            }
            _playerRepository.Create(player);
            return true;
        }

        /*public PlayerWithStatistics? GetById(String id)
        {
            try
            {
                Guid guid = Guid.Parse(id);
                Player player = _playerRepository.GetById(guid);
                IEnumerable<PlayerStatistic> playerStatistics = _playerStatisticRepository.GetForPlayerAndYear(player, GetYearForCurrentSeason());
                PlayerWithStatistics playerWithStatistics = new PlayerWithStatistics(player, playerStatistics);
                return playerWithStatistics;
            }

            catch (Exception)
            {
                return null;
            }

        }*/

        public int GetYearForCurrentSeason()
        {
            DateTime currentDate = DateTime.Today;
            if (currentDate.Month >= 7)
            {
                return currentDate.Year;
            }
            return currentDate.Year - 1;
        }

    }
}
