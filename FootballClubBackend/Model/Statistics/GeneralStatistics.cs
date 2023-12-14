using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballClubBackend.Model.Statistics
{
    public class GeneralStatistics
    {
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

        public GeneralStatistics(IEnumerable<GeneralStatistics> statistics)
        {
            GamesPlayed = statistics.Count();
            MinutesPlayed = statistics.Sum(s=>s.MinutesPlayed);
            FoulsWon = statistics.Sum(s => s.FoulsWon);
            FoulsConceded = statistics.Sum(s => s.FoulsConceded);
            YellowCards = statistics.Sum(s => s.YellowCards);
            RedCards = statistics.Sum(s => s.RedCards);
        }

        public GeneralStatistics() { }
    }
}
