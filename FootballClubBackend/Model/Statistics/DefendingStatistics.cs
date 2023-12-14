using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FootballClubBackend.Model.Statistics
{
    public class DefendingStatistics
    {
        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int Clearances { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int Blocks { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int Interceptions { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, 100)]
        public int SuccessfulTackles { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, 100)]
        public int TotalTackles { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, 100)]
        public int SuccessfulAerialDuels { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, 100)]
        public int TotalAerialDuels { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, 100)]
        public int SuccessfulGroundDuels { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, 100)]
        public int TotalGroundDuels { get; set; }

        public DefendingStatistics() { }

        public DefendingStatistics(IEnumerable<DefendingStatistics?> statistics)
        {
            if (statistics != null)
            {
                Clearances = statistics.Sum(x => x.Clearances);
                Blocks = statistics.Sum(x => x.Blocks);
                Interceptions = statistics.Sum(x => x.Interceptions);
                SuccessfulTackles = statistics.Sum(x => x.SuccessfulTackles);
                TotalTackles = statistics.Sum(x => x.TotalTackles);
                SuccessfulGroundDuels = statistics.Sum(x => x.SuccessfulGroundDuels);
                TotalAerialDuels = statistics.Sum(x => x.TotalAerialDuels);
                SuccessfulGroundDuels = statistics.Sum(x => x.SuccessfulGroundDuels);
                TotalGroundDuels = statistics.Sum(x => x.TotalGroundDuels);
            }
        }
    }
}
