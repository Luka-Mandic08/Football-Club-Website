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
            var referenceDate = new DateTime();
            return _matchRepository.GetFixtures(referenceDate);
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
                        // Swap the elements
                        var temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        swapped = true;
                    }
                }

                // If no two elements were swapped, the list is already sorted
                if (!swapped)
                    break;
            }
        }
    }
}
