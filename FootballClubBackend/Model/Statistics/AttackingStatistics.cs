using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FootballClubBackend.Model.Statistics
{
    public class AttackingStatistics
    {
        
        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int TotalShots { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int ShotsOnTarget { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int TotalGoals { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int RightFootedGoals { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int LeftFootedGoals { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int HeadedGoals { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int FreekickGoals { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int Assists { get; set; }

        public AttackingStatistics() { }

        public AttackingStatistics(IEnumerable<AttackingStatistics?> statistics)
        {
            if (statistics != null)
            {
                TotalShots = statistics.Sum(x => x.TotalShots);
                ShotsOnTarget = statistics.Sum(x => x.ShotsOnTarget);
                TotalGoals = statistics.Sum(x => x.TotalGoals);
                RightFootedGoals = statistics.Sum(x => x.RightFootedGoals);
                LeftFootedGoals = statistics.Sum(x => x.LeftFootedGoals);
                HeadedGoals = statistics.Sum(x => x.HeadedGoals);
                FreekickGoals = statistics.Sum(x => x.FreekickGoals);
                Assists = statistics.Sum(x => x.Assists);
            }
        }

    }
}
