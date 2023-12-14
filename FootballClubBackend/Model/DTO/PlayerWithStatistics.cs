using FootballClubBackend.Model.Statistics;

namespace FootballClubBackend.Model.DTO
{
    public class PlayerWithStatistics
    {
        public Player player {  get; set; }

        public PlayerStatistic statistic { get; set; }
        public PlayerWithStatistics(Player player, ICollection<PlayerStatistic> statistic)
        {
            this.player = player;
            this.statistic = new PlayerStatistic(statistic, player.Position == Enums.Position.Goalkeeper);
        }
    }
}
