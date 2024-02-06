using FootballClubBackend.Model.DTO;
using FootballClubBackend.Model.Enums;
using FootballClubBackend.Model.Statistics;
using FootballClubBackend.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace FootballClubBackend.Service
{
    public class PlayerStatisticService
    {
        private readonly PlayerStatisticRepository _playerStatisticRepository;
        private readonly PlayerRepository _playerRepository;

        public PlayerStatisticService(PlayerStatisticRepository playerStatisticRepository, PlayerRepository playerRepository)
        {
            _playerStatisticRepository = playerStatisticRepository;
            _playerRepository = playerRepository;
        }

        public PlayerStatisticsDto GetAllForMatch(Guid matchId)
        {
            ICollection<PlayerStatistic> statistics = _playerStatisticRepository.GetAllForMatchForSquad(matchId);
            ICollection<PlayerStatistic> opponentStatistics = _playerStatisticRepository.GetAllForMatchForOpponentSquad(matchId);
            return new PlayerStatisticsDto(statistics, opponentStatistics);
        }

        public PlayerStatistic GetAllForPlayerBySeasonAndCompetition(GetStatisticsForPlayerDto dto)
        {
            ICollection<PlayerStatistic> statistics;
            bool isGoalkeeper;
            if (dto.Id != null && !dto.Id.Equals(""))
            {
                Guid guid = Guid.Parse(dto.Id);
                statistics = _playerStatisticRepository.GetAllForPlayerBySeasonAndCompetitionById(guid, dto.Season, dto.Competition);
                isGoalkeeper = _playerRepository.GetById(guid).Position == Position.Goalkeeper;
            }
            else
            {
                string name = dto.Name.Replace("-", " ");
                statistics = _playerStatisticRepository.GetAllForPlayerBySeasonAndCompetitionByName(name, dto.Season, dto.Competition);
                var split = name.Split(' ');
                isGoalkeeper = _playerRepository.GetByName(split[0], split[1]).Position == Position.Goalkeeper;
            }
            if(statistics.Count > 0) 
                return new PlayerStatistic(statistics,isGoalkeeper);
            return new PlayerStatistic();
        }

        public PlayerStatisticsDto Create(PlayerStatistic playerStatistic)
        {
            _playerStatisticRepository.Create(playerStatistic);
            ICollection<PlayerStatistic> statistics = _playerStatisticRepository.GetAllForMatchForSquad(playerStatistic.MatchId);
            ICollection<PlayerStatistic> opponentStatistics = _playerStatisticRepository.GetAllForMatchForOpponentSquad(playerStatistic.MatchId);
            return new PlayerStatisticsDto(statistics, opponentStatistics);
        }
    }
}
