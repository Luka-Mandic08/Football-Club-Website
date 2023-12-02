using FootballClubBackend.Model.Statistics;

namespace FootballClubBackend.Model.DTO
{
    public class MatchStatisticsDto
    {
        public MatchStatistics? Statistics { get; set; }
        public MatchStatistics? OpponentStatistics { get; set; }
    }
}
