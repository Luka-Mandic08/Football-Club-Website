using FootballClubBackend.Model;
using FootballClubBackend.Model.DTO;
using FootballClubBackend.Repository;

namespace FootballClubBackend.Service
{
    public class MatchService
    {
        private readonly MatchRepository _matchRepository;

        public MatchService(MatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public bool Create(CreateMatch dto)
        {
            Match match = new Match(dto);
            return _matchRepository.Create(match) != null;
        }
    }
}
