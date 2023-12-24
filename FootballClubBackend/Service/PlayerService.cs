using FootballClubBackend.Model;
using FootballClubBackend.Model.DTO;
using FootballClubBackend.Model.Statistics;
using FootballClubBackend.Repository;
using System.Collections.Generic;

namespace FootballClubBackend.Service
{
    public class PlayerService
    {
        private readonly PlayerRepository _playerRepository;

        public PlayerService(PlayerRepository playerRepository, PlayerStatisticRepository playerStatisticRepository)
        {
            _playerRepository = playerRepository;
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

        public ICollection<PlayerForSquad> GetAll()
        { 
            ICollection<Player> players = _playerRepository.GetAll();
            ICollection<PlayerForSquad> squadPlayers = new List<PlayerForSquad>();
            foreach (Player player in players)
            {
                squadPlayers.Add(new PlayerForSquad(player));
            }
            return squadPlayers;
        }
        public AllPlayersDto GetActiveAndLoaned()
        {
            return new AllPlayersDto(_playerRepository.GetAllActive(), _playerRepository.GetAllLoaned());
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

    }
}
