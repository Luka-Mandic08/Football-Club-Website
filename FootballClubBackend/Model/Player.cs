using FootballClubBackend.Model.DTO;
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
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string PlaceOfBirth { get; set; }

        [Required]
        public Team Team { get; set; }

        [Required]
        public Position Position { get; set; }

        [Range(1, 99)]
        public int SquadNumber { get; set; }

        [Required]
        public FirstTeamStatus Status { get; set; }

        [Required]
        public DateTime DateJoined { get; set; }

        [Required]
        public string Image {  get; set; }

        public Player(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public Player(string name, string surname, DateTime dateOfBirth, string placeOfBirth, Team team, Position position, int squadNumber, FirstTeamStatus status, DateTime dateJoined, string image)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            PlaceOfBirth = placeOfBirth;
            Team = team;
            Position = position;
            SquadNumber = squadNumber;
            Status = status;
            DateJoined = dateJoined;
            Image = image;
        }

        public Player(CreatePlayer dto)
        {
            Name = dto.Name;
            Surname = dto.Surname;
            DateOfBirth = dto.DateOfBirth;
            PlaceOfBirth = dto.PlaceOfBirth;
            Team = (Team)dto.Team;
            Position = (Position)dto.Position;
            SquadNumber = dto.SquadNumber;
            Status = (FirstTeamStatus)dto.Status; 
            DateJoined = dto.DateJoined;
            Image = dto.Image;
        }
    }
}
