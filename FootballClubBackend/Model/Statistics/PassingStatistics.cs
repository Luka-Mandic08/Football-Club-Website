using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FootballClubBackend.Model.Statistics
{
    public class PassingStatistics
    {

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int TotalPasses { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int CompletedPasses { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int TotalLongPasses { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int CompletedLongPasses { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int CompletedCrosses { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int SecondAssists { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int KeyPasses { get; set; }

        public PassingStatistics() { }

        public PassingStatistics(IEnumerable<PassingStatistics> statistics)
        {
            TotalPasses = statistics.Sum(x => x.TotalPasses);
            CompletedPasses = statistics.Sum(x => x.CompletedPasses);
            TotalLongPasses = statistics.Sum(x => x.TotalLongPasses);
            CompletedLongPasses = statistics.Sum(x => x.CompletedLongPasses);
            CompletedCrosses = statistics.Sum(x => x.CompletedCrosses);
            SecondAssists = statistics.Sum(x => x.SecondAssists);
            KeyPasses = statistics.Sum(x => x.KeyPasses);
        }
    }
}
