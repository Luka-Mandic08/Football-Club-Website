using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FootballClubBackend.Model.Statistics
{
    public class PlayerStatistics
    {
        [Key]
        public Guid? Id { get; set; }

        [Required]
        public Guid MatchId { get; set; }

        public Guid PlayerId { get; set; }

        public string? PlayerName { get; set; }

        public int Season { get; set; }

        public string Team { get; set; }

        public PassingStatistics PassingStatistics
        {
            get => default;
            set
            {
            }
        }

        public GoalkeepingStatistics GoalkeepingStatistics
        {
            get => default;
            set
            {
            }
        }

        public GeneralStatistics GeneralStatistics
        {
            get => default;
            set
            {
            }
        }

        public AttackingStatistics AttackingStatistics
        {
            get => default;
            set
            {
            }
        }

        public DefendingStatistics DefendingStatistics
        {
            get => default;
            set
            {
            }
        }

        public PlayerStatistics()
        { }

    }
}
