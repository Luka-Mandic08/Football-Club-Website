using FootballClubBackend.Model;
using FootballClubBackend.Model.DTO;
using FootballClubBackend.Model.Statistics;
using FootballClubBackend.Repository;

namespace FootballClubBackend.Service
{
    public class MatchService
    {
        private readonly MatchRepository _matchRepository;
        private readonly PlayerRepository _playerRepository;

        public MatchService(MatchRepository matchRepository,PlayerRepository playerRepository)
        {
            _matchRepository = matchRepository;
            _playerRepository = playerRepository;
        }

        public string Create(CreateMatch dto)
        {
            Match match = new Match(dto);
            if (_matchRepository.GetByDate(match.Start) != null)
            {
                return _matchRepository.Create(match)?"Ok":"Add image";
            }
            return "Date taken";
        }

        public IEnumerable<Match> GetFixtures()
        {
            return _matchRepository.GetFixtures();
        }

        public IEnumerable<Match> GetResults()
        {
            return _matchRepository.GetResults();
        }

        public Match GetById(Guid id)
        {
            return _matchRepository.GetById(id);
        }
        
        public Match? GetByDate(DateTime start)
        {
            return _matchRepository.GetByDate(start);
        }

        public ICollection<MatchEvent>? GetMatchEvents(Guid id)
        {
            return _matchRepository.GetById(id).MatchEvents;
        }

        public Match UpdateMatchEvents(Guid id, ICollection<MatchEvent> events)
        {
            BubbleSort((List<MatchEvent>)events);
            return _matchRepository.UpdateMatchEvents(id, events);
        }

        public void BubbleSort(List<MatchEvent> list)
        {
            int n = list.Count;
            bool swapped;
            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (list[j + 1].IsBefore(list[j]))
                    {
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
        }

        public Squads GetMatchSquads(Guid id)
        {
            Match match = _matchRepository.GetById(id);
            var squadIds = match.SquadIds;
            var subsIds = match.SubsIds;
            var opponentSquad = match.OpponentSquad;
            var opponentSubs = match.OpponentSubs;
            var squad = _playerRepository.GetInMatchSquad(squadIds);
            var subs = _playerRepository.GetInMatchSquad(subsIds);
            ICollection<Player> eligiblePlayers;
            if (squadIds != null || subsIds!=null) {
                eligiblePlayers = _playerRepository.GetEligibleForMatch(squadIds,subsIds);
            }
            else
            {
                eligiblePlayers = _playerRepository.GetAllActive();
            }
            return new Squads(squad,eligiblePlayers,opponentSquad,subs,opponentSubs);
        }

        public Squads UpdateMatchSquads(Guid id,Squads squads)
        {
            Match updatedMatch = _matchRepository.UpdateMatchSquads(id, squads.Squad.Select(s => s.Id).ToList(), squads.Subs.Select(s => s.Id).ToList(), squads.OpponentSquad, squads.OpponentSubs);
            squads.UpdateEligiblePlayers(_playerRepository.GetEligibleForMatch(updatedMatch.SquadIds,updatedMatch.SubsIds));
            return squads;
        }

        public MatchStatisticsDto GetMatchStatistics(Guid id)
        {
            MatchStatisticsDto dto = new MatchStatisticsDto();
            Match match = _matchRepository.GetById(id);
            dto.Statistics = match.Statistics;
            dto.OpponentStatistics = match.OpponentStatistics;
            return dto;
        }

        public Match UpdateMatchStatistics(Guid id,MatchStatisticsDto dto)
        {
            MatchStatistics? statistics = dto.Statistics;
            MatchStatistics? opponentStatistics = dto.OpponentStatistics;
            return _matchRepository.UpdateMatchStatistics(id,statistics,opponentStatistics);           
        }


    }
}
