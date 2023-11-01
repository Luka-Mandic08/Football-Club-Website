using FootballClubBackend.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace FootballClubBackend.Model.DTO
{
    public class CreatePlayer
    {
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Surname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string PlaceOfBirth { get; set; }

        [Required]
        public int Position { get; set; }

        [Range(1, 99)]
        public int SquadNumber { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
