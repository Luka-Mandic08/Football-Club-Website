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
        [Range(0, int.MaxValue)]
        public int NumberOfShotsFaced { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int CleanSheets { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int PenaltiesSaved { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int Catches { get; set; }

        public GoalkeepingStatistics() { }

        public GoalkeepingStatistics(IEnumerable<GoalkeepingStatistics?> statistics)
        {
            if (statistics != null)
            {
                NumberOfSaves = statistics.Sum(x => x.NumberOfSaves);
                NumberOfShotsFaced = statistics.Sum(x => x.NumberOfShotsFaced);
                CleanSheets = statistics.Sum(x => x.CleanSheets);
                PenaltiesSaved = statistics.Sum(x => x.PenaltiesSaved);
                Catches = statistics.Sum(x => x.Catches);
            }
        }
    }
}
