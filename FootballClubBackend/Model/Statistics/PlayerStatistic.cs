using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballClubBackend.Model.Statistics
{
    public class PlayerStatistic
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Competition { get; set; }

        [ForeignKey("PlayerId")]
        public Guid PlayerId { get; set; }

        [Required]
        public GeneralStatistics GeneralStatistics { get; set; }

        [Required]
        public PassingStatistics PassingStatistics { get; set; }

    }
}
