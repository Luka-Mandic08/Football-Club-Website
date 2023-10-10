using System.ComponentModel.DataAnnotations;

namespace FootballClubBackend.Model.DTO
{
    public class CreateMatch
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Opponent {  get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Venue { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Referee { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Competition { get; set; }
        [Required]
        public DateTime Start { get; set; }
    }
}
