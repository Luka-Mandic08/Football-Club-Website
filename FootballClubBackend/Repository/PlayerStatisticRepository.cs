using FootballClubBackend.Model;
using FootballClubBackend.Model.Statistics;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FootballClubBackend.Repository
{
    public class PlayerStatisticRepository
    {
        private readonly IMongoCollection<PlayerStatistics> collection;
        private readonly IMongoDatabase database;

        public PlayerStatisticRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("FootballClubDb");
            collection = database.GetCollection<PlayerStatistics>("PlayerStatistics");
        }

        public ICollection<PlayerStatistics> GetAllForMatchForSquad(Guid matchId)
        {
            var filter = Builders<PlayerStatistics>.Filter.And(
                Builders<PlayerStatistics>.Filter.Eq(s => s.MatchId, matchId),
                Builders<PlayerStatistics>.Filter.Eq(s => s.Team, "FK FTN"));
            return collection.Find(filter).ToList();
        }

        public ICollection<PlayerStatistics> GetAllForMatchForOpponentSquad(Guid matchId)
        {
            var filter = Builders<PlayerStatistics>.Filter.And(
                Builders<PlayerStatistics>.Filter.Eq(s => s.MatchId, matchId),
                Builders<PlayerStatistics>.Filter.Ne(s => s.Team, "FK FTN"));
            return collection.Find(filter).ToList();
        }

        public ICollection<PlayerStatistics> GetAllForPlayerBySeasonAndCompetitionById(Guid playerId,int season,string competition)
        {
            var filters = new List<FilterDefinition<PlayerStatistics>>();
            filters.Add(Builders<PlayerStatistics>.Filter.Eq(s => s.PlayerId, playerId));
            filters.Add(Builders<PlayerStatistics>.Filter.Eq(s => s.Season, season));
            if (!competition.Equals("any"))
            {
                filters.Add(Builders<PlayerStatistics>.Filter.Eq(s => s.Competition, competition));
            }
            var filter = Builders<PlayerStatistics>.Filter.And(filters);
            return collection.Find(filter).ToList();
        }

        public ICollection<PlayerStatistics> GetAllForPlayerBySeasonAndCompetitionByName(string name, int season, string competition)
        {
            var filters = new List<FilterDefinition<PlayerStatistics>>();
            filters.Add(Builders<PlayerStatistics>.Filter.Eq(s => s.PlayerName, name));
            filters.Add(Builders<PlayerStatistics>.Filter.Eq(s => s.Season, season));
            if (!competition.Equals("any"))
            {
                filters.Add(Builders<PlayerStatistics>.Filter.Eq(s => s.Competition, competition));
            }
            var filter = Builders<PlayerStatistics>.Filter.And(filters);
            return collection.Find(filter).ToList();
        }

        public void Create(PlayerStatistics playerStatistic)
        {
            PlayerStatistics? oldStatistics = GetForPlayerAndMatch(playerStatistic.MatchId, playerStatistic.PlayerId);
            if (oldStatistics != null)
            {
                Delete(oldStatistics);
            }
            playerStatistic.Id = Guid.NewGuid();
            collection.InsertOne(playerStatistic);
        }

        public PlayerStatistics? GetForPlayerAndMatch(Guid matchId, Guid playerId)
        {
            var filter = Builders<PlayerStatistics>.Filter.And(
                Builders<PlayerStatistics>.Filter.Eq(s => s.PlayerId, playerId),
                Builders<PlayerStatistics>.Filter.Eq(s => s.MatchId, matchId));
            return collection.Find(filter).FirstOrDefault();
        }

        public void Delete(PlayerStatistics playerStatistic)
        {
            collection.DeleteOne(playerStatistic.ToBsonDocument());
        }

    }
}
