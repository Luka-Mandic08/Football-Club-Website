namespace FootballClubBackend.Model.DTO
{
    public class Register
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }

    }
}
