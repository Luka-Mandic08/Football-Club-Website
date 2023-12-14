using FootballClubBackend.Model.Statistics;

namespace FootballClubBackend.Model.DTO
{
    public class PlayerStatisticsDto
    {

        public ICollection<PlayerStatistic> Statistics { get; set; }
        public ICollection<PlayerStatistic> OpponentStatistics { get; set; }

        public PlayerStatisticsDto() { }

        public PlayerStatisticsDto(ICollection<PlayerStatistic> statistics, ICollection<PlayerStatistic> opponentStatistics) 
        {
            Statistics = statistics;
            OpponentStatistics = opponentStatistics;
        }
    }
}
