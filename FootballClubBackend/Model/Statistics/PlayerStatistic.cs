using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FootballClubBackend.Model.Statistics
{
    public class PlayerStatistic
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Competition { get; set; }

        [ForeignKey("PlayerId")]
        public Guid PlayerId { get; set; }

        [Required]
        public GeneralStatistics GeneralStatistics { get; set; }

        [Required]
        public PassingStatistics PassingStatistics { get; set; }

        public GoalkeepingStatistics? GoalkeepingStatistics { get; set;}
        
        public DefendingStatistics? DefendingStatistics { get; set; }   

        public AttackingStatistics? AttackingStatistics { get; set; }

        public PlayerStatistic(int year, string competition,Guid playerId,bool isGoalkeeper)
        {
            Year = year;
            Competition = competition;
            PlayerId = playerId;
            GeneralStatistics = new GeneralStatistics();
            PassingStatistics = new PassingStatistics();
            if (isGoalkeeper)
            {
                GoalkeepingStatistics = new GoalkeepingStatistics();
            }
            else
            {
                DefendingStatistics = new DefendingStatistics();
                AttackingStatistics = new AttackingStatistics();
            }
        }

        public PlayerStatistic() { }

    }
}
