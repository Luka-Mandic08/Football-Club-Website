namespace FootballClubBackend.Model.DTO
{
    public class AllPlayersDto
    {
        public ICollection<Player> ActivePlayers { get; set; }
        public ICollection<Player> LoanedPlayers { get; set; }

        public AllPlayersDto() { }

        public AllPlayersDto(ICollection<Player> activePlayers, ICollection<Player> loanedPlayers)
        {
            ActivePlayers = activePlayers;
            LoanedPlayers = loanedPlayers;
        }
    }
}
