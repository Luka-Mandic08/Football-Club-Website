using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FootballClubBackend.Model.Statistics
{
    public class PassingStatistics
    {
        [Key]
        public Guid Id { get; set; }

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
    }
}
