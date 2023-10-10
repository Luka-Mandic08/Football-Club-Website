using System.ComponentModel.DataAnnotations;

namespace FootballClubBackend.Model
{
    public class MatchEvent
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Text { get; set; }

        [Required]
        public string Minute { get; set; }

        [Required]
        public virtual Match Match { get; set; }
    }
}
