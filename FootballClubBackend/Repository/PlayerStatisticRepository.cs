using FootballClubBackend.Model;
using FootballClubBackend.Model.Statistics;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FootballClubBackend.Repository
{
    public class PlayerStatisticRepository
    {
        private readonly IMongoCollection<PlayerStatistic> collection;
        private readonly IMongoDatabase database;

        public PlayerStatisticRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("FootballClubDb");
            collection = database.GetCollection<PlayerStatistic>("PlayerStatistics");
        }

        public ICollection<PlayerStatistic> GetAllForMatchForSquad(Guid matchId)
        {
            var filter = Builders<PlayerStatistic>.Filter.And(
                Builders<PlayerStatistic>.Filter.Eq(s => s.MatchId, matchId),
                Builders<PlayerStatistic>.Filter.Eq(s => s.Team, "FK FTN"));
            return collection.Find(filter).ToList();
        }

        public ICollection<PlayerStatistic> GetAllForMatchForOpponentSquad(Guid matchId)
        {
            var filter = Builders<PlayerStatistic>.Filter.And(
                Builders<PlayerStatistic>.Filter.Eq(s => s.MatchId, matchId),
                Builders<PlayerStatistic>.Filter.Ne(s => s.Team, "FK FTN"));
            return collection.Find(filter).ToList();
        }

        public ICollection<PlayerStatistic> GetAllForPlayerBySeasonAndCompetitionById(Guid playerId,int season,string competition)
        {
            var filter = Builders<PlayerStatistic>.Filter.And(
                Builders<PlayerStatistic>.Filter.Eq(s => s.PlayerId, playerId),
                Builders<PlayerStatistic>.Filter.Eq(s => s.Season, season),
                Builders<PlayerStatistic>.Filter.Eq(s => s.Competition, competition));
            return collection.Find(filter).ToList();
        }

        public ICollection<PlayerStatistic> GetAllForPlayerBySeasonAndCompetitionByName(string name, int season, string competition)
        {
            var filter = Builders<PlayerStatistic>.Filter.And(
                Builders<PlayerStatistic>.Filter.Eq(s => s.PlayerName, name),
                Builders<PlayerStatistic>.Filter.Eq(s => s.Season, season),
                Builders<PlayerStatistic>.Filter.Eq(s => s.Competition, competition));
            return collection.Find(filter).ToList();
        }

        public void Create(PlayerStatistic playerStatistic)
        {
            PlayerStatistic? oldStatistics = GetForPlayerAndMatch(playerStatistic.MatchId, playerStatistic.PlayerId);
            if (oldStatistics != null)
            {
                Delete(oldStatistics);
            }
            playerStatistic.Id = Guid.NewGuid();
            collection.InsertOne(playerStatistic);
        }

        public PlayerStatistic? GetForPlayerAndMatch(Guid matchId, Guid playerId)
        {
            var filter = Builders<PlayerStatistic>.Filter.And(
                Builders<PlayerStatistic>.Filter.Eq(s => s.PlayerId, playerId),
                Builders<PlayerStatistic>.Filter.Eq(s => s.MatchId, matchId));
            return collection.Find(filter).FirstOrDefault();
        }

        public void Delete(PlayerStatistic playerStatistic)
        {
            collection.DeleteOne(playerStatistic.ToBsonDocument());
        }

    }
}
