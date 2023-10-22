using FootballClubBackend.Model.DTO;
using FootballClubBackend.Model.Statistics;
using System.ComponentModel.DataAnnotations;

namespace FootballClubBackend.Model
{
    public class Match
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Venue { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Opponent { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Referee { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Competition { get; set; }

        public int? Attendance {  get; set; }

        public ICollection<MatchEvent>? MatchEvents { get; set; }

        public MatchStatistics Statistics { get; set; }
        public MatchStatistics? OpponentStatistics { get; set; }

        public ICollection<PlayerStatistic>? SquadStatistics {  get; set; }
        public ICollection<PlayerStatistic>? OpponentSquadStatistics { get; set; }

        public Match()
        {

        }

        public Match(CreateMatch dto)
        {
            Venue = dto.Venue;
            Start = dto.Start.AddHours(1);
            Referee = dto.Referee;
            Opponent = dto.Opponent;
            Competition = dto.Competition;
        }
    }
}
