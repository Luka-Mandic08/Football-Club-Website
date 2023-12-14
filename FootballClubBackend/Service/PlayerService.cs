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

        public AllPlayersDto GetAll()
        {

            return new AllPlayersDto(_playerRepository.GetAllActive(), _playerRepository.GetAllLoaned());
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

        public Player GetPlayerByNameOrId(string name, string id)
        {
            if (id != null && !id.Equals(""))
            {
                return _playerRepository.GetById(Guid.Parse(id));
            }
            name = name.Replace("-", " ");
            var names = name.Split(' ');
            return _playerRepository.GetByName(names[0], names[1]);
        }

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
