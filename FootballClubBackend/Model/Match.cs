using FootballClubBackend.Model.DTO;
using FootballClubBackend.Model.Statistics;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

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

        [Required]
        public string Badge { get; set; }

        public int? Attendance {  get; set; }

        public ICollection<MatchEvent>? MatchEvents { get; set; }

        public MatchStatistics? Statistics { get; set; }
        public MatchStatistics? OpponentStatistics { get; set; }

        public ICollection<Guid>? SquadIds {  get; set; }
        public ICollection<Guid>? SubsIds { get; set; }
        public ICollection<PlayerForSquad>? OpponentSquad { get; set; }
        public ICollection<PlayerForSquad>? OpponentSubs { get; set; }

        public Match()
        {

        }

        public Match(CreateMatch dto)
        {
            Venue = dto.Venue;
            Start = dto.Start;
            Referee = dto.Referee;
            Opponent = dto.Opponent;
            Competition = dto.Competition;
            Badge = "assets/Images/Badges/" + dto.Badge.Split('\\').Last();
        }

        
    }
}
