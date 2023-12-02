using FootballClubBackend.Model.DTO;
using System.ComponentModel.DataAnnotations;

namespace FootballClubBackend.Model
{
    public class User
    {
        public Guid Id {  get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(128)]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Surname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Country { get; set; }
        [Required]
        public string Gender { get; set; }

        public User(Register dto,string role)
        {
            Email = dto.Email;
            Password = dto.Password;
            Role = role;
            Name = dto.Name;
            Surname = dto.Surname;
            DateOfBirth = dto.DateOfBirth;
            Country = dto.Country;
            Gender = dto.Gender;
        }
    }
}
