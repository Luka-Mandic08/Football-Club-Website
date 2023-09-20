using FootballClubBackend.Model.Statistics;

namespace FootballClubBackend.Model.DTO
{
    public class PlayerWithStatistics
    {
        public Player player {  get; set; }

        public IEnumerable<PlayerStatistic> statistic { get; set; }
        public PlayerWithStatistics(Player player, IEnumerable<PlayerStatistic> statistic)
        {
            this.player = player;
            this.statistic = statistic;
        }
    }
}
