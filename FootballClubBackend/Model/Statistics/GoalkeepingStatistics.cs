using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FootballClubBackend.Model.Statistics
{
    public class GoalkeepingStatistics
    {
        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int NumberOfSaves { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, 100)]
        public float SavePercentage { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int CleanSheets { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int PenaltiesSaved { get; set; }
    }
}
