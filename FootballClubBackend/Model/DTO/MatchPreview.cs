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
        public int? Goals { get; set; }
        public int? OpponentGoals { get; set; }
        public int Season {  get; set; }
        public string Badge { get; set; }

        public MatchPreview(Match match)
        {
            Id = match.Id.ToString();
            Opponent = match.Opponent;
            Venue = match.Venue;
            Referee = match.Referee;
            Competition = match.Competition;
            Start = match.Start;
            Badge = match.Badge;
            Goals = match.Statistics != null ? match.Statistics.AttackingMatchStatistics.Goals : -1;
            OpponentGoals = match.Statistics != null ? match.OpponentStatistics.AttackingMatchStatistics.Goals : -1; 
            Season = Start.Year;
            if (Start.Month <= 6)
            {
                --Season;
            }
        }

        public MatchPreview() { }
    }
}
