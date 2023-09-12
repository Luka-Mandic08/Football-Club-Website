using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballClubBackend.Model.Statistics
{
    public class GeneralStatistics
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int GamesPlayed { get; set; }
        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int MinutesPlayed { get; set; }
        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int Starts { get; set; }
        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int SubbedOff { get; set; }
        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int FoulsWon { get; set; }
        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int FoulsConceded { get; set; }
        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int YellowCards { get; set; }
        [Required]
        [DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int RedCards { get; set; }

    }
}
