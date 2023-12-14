using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FootballClubBackend.Model.Statistics
{
    public class PlayerStatistic
    {
        [Key]
        public Guid? Id { get; set; }

        [Required]
        public Guid MatchId { get; set; }

        public Guid PlayerId { get; set; }

        public string? PlayerName { get; set; }

        public int Season { get; set; }

        public string Competition {  get; set; }

        public string Team { get; set; }

        [Required]
        public GeneralStatistics GeneralStatistics { get; set; }

        [Required]
        public PassingStatistics PassingStatistics { get; set; }

        public GoalkeepingStatistics? GoalkeepingStatistics { get; set;}
        
        public DefendingStatistics? DefendingStatistics { get; set; }   

        public AttackingStatistics? AttackingStatistics { get; set; }

        public PlayerStatistic() { }

        public PlayerStatistic(ICollection<PlayerStatistic> statistics, bool isGoalkeeper)
        {
            GeneralStatistics = new GeneralStatistics(statistics.Select(s => s.GeneralStatistics));
            PassingStatistics = new PassingStatistics(statistics.Select(s => s.PassingStatistics));
            if (isGoalkeeper)
            {
                GoalkeepingStatistics = new GoalkeepingStatistics(statistics.Select(s => s.GoalkeepingStatistics));
            }
            else
            {
                DefendingStatistics = new DefendingStatistics(statistics.Select(s => s.DefendingStatistics));
                AttackingStatistics = new AttackingStatistics(statistics.Select(s => s.AttackingStatistics));
            }

            PlayerId = statistics.Select(s => s.PlayerId).First();
            PlayerName = statistics.Select(s => s.PlayerName).First();
            Season = statistics.Select(s => s.Season).First();
            Competition = statistics.Select(s => s.Competition).First();
            Team = statistics.Select(s => s.Team).First();
        }

    }
}
