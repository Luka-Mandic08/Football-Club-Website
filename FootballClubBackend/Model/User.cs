namespace FootballClubBackend.Model
{
    public class User
    {
        public Guid Id {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
    }
}
