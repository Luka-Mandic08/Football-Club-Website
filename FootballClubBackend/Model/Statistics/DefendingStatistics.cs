using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FootballClubBackend.Model.Statistics
{
    public class DefendingStatistics
    {
        [Key]
        public Guid Id { get; set; }

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
        public int Interception { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, 100)]
        public float TackleSuccessRate { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, 100)]
        public float AerialDuelSuccessRate { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, 100)]
        public float GroundDuelSuccessRate { get; set; }
    }
}
