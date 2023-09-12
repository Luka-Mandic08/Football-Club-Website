using FootballClubBackend.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;
namespace FootballClubBackend.Model
{
    public class Player
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Surname { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public Team Team { get; set; }

        [Required]
        public Position Position { get; set; }

        [Range(1, 99)]
        public int SquadNumber { get; set; }

        [Required]
        public FirstTeamStatus Status { get; set; }

        [Required]
        public string Image {  get; set; }

        public Player(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
