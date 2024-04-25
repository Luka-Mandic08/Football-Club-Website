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
            if (_matchRepository.GetByDate(match.Start) == null)
            {
                _matchRepository.Create(match);
                return "Ok";
            }
            return "Date taken";
        }

        public Match? Update(Match match)
        {
            if (_matchRepository.GetByDate(match.Start) == null)
            {
                return _matchRepository.Update(match);
            }
            return null;
        }

        public ICollection<Match> GetFixtures(string competition)
        {
            return _matchRepository.GetFixtures(competition);
        }

        public ICollection<Match> GetResults(string competition,int year)
        {
            if(isCurrentSeason(year))
            {
                return _matchRepository.GetResults(competition, new DateTime(year,7,1), DateTime.Now);
            }         
            return _matchRepository.GetResults(competition, new DateTime(year, 7, 1), new DateTime(year+1, 6, 30));
        }

        public ICollection<Match> GetForNewArticle()
        {
            return _matchRepository.GetForNewArticle().ToList();
        }

        public ICollection<Match> GetForHomePage()
        {
            return _matchRepository.GetForHomePage().ToList();
        }

        public MatchPreview GetByDate(DateTime start)
        {
            Match? match = _matchRepository.GetByDate(start);
            return match!=null? new MatchPreview(match) : new MatchPreview();
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

        public Squads? GetMatchSquads(Guid id)
        {
            Match match = _matchRepository.GetById(id);
            if (match == null)
                return null;
            var squadIds = match.SquadIds;
            var subsIds = match.SubsIds;
            var opponentSquad = match.OpponentSquad;
            var opponentSubs = match.OpponentSubs;
            var squad = _playerRepository.
                GetInMatchSquad(squadIds);
            var subs = _playerRepository.
                GetInMatchSquad(subsIds);
            ICollection<Player> eligiblePlayers;
            if (squadIds != null || subsIds != null)
            {
                eligiblePlayers = _playerRepository.
                    GetEligibleForMatch(squadIds,subsIds);
            }
            else
            {
                eligiblePlayers = _playerRepository.
                    GetAllActive();
            }
            return new Squads(squad,eligiblePlayers,
                opponentSquad,subs,opponentSubs);
        }

        public Squads UpdateMatchSquads(Guid id,Squads squads)
        {
            foreach(PlayerForSquad player in squads.OpponentSquad)
            {
                if (player.Id == "" || player.Id == null)
                {
                    player.Id = Guid.NewGuid().ToString();
                }
            }
            foreach (PlayerForSquad player in squads.OpponentSubs)
            {
                if (player.Id == "" || player.Id == null)
                {
                    player.Id = Guid.NewGuid().ToString();
                }
            }
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

        private bool isCurrentSeason(int year)
        {
            return DateTime.Now > new DateTime(year, 7, 1) && DateTime.Now < new DateTime(year + 1, 6, 30);
        }
    }
}
