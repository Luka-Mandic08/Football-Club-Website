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
            _matchRepository.Create(match);
            return true;
        }

        public IEnumerable<Match> GetFixtures()
        {
            var referenceDate = new DateTime();
            return _matchRepository.GetFixtures(referenceDate);
        }

        public IEnumerable<Match> GetResults()
        {
            return _matchRepository.GetResults();
        }

        public Match GetMatch(Guid id)
        {
            return _matchRepository.GetMatch(id);
        }
    }
}
