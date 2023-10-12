using System.ComponentModel.DataAnnotations;

namespace FootballClubBackend.Model.DTO
{
    public class MatchPreview
    {
        public string Id { get; set; }
        public string Opponent { get; set; }
        public string Venue { get; set; }
        public string Referee { get; set; }
        public string Competition { get; set; }
        public DateTime Start { get; set; }
        public int Goals { get; set; }
        public int OpponentGoals { get; set; }

        public MatchPreview(Match match,bool isResult)
        {
            Id = match.Id.ToString();
            Opponent = match.Opponent;
            Venue = match.Venue;
            Referee = match.Referee;
            Competition = match.Competition;
            Start = match.Start;
            if (isResult)
            {
                Goals = match.Statistics.AttackingMatchStatistics.Goals;
                OpponentGoals = match.OpponentStatistics.AttackingMatchStatistics.Goals;
            }
        }
    }
}
