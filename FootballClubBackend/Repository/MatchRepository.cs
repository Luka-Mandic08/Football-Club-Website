using FootballClubBackend.Database;
using FootballClubBackend.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FootballClubBackend.Repository
{
    public class MatchRepository
    {
        private readonly IMongoCollection<Match> collection;

        public MatchRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("FootballClubDb");
            collection = database.GetCollection<Match>("Matches");
        }

        public void Create(Match match)
        {
            match.Id = Guid.NewGuid();
            collection.InsertOne(match);
            return;
        }

        public IEnumerable<Match> GetFixtures(DateTime refDate)
        {
            var filter = Builders<Match>.Filter.Gte(m => m.Start, refDate);
            return collection.Find(filter).ToList();
        }

        public IEnumerable<Match> GetResults() 
        {
            var filter = Builders<Match>.Filter.Ne(m => m.Statistics, null);
            return collection.Find(filter).ToList();
        }

        public Match GetMatch(Guid id)
        {
            var filter = Builders<Match>.Filter.Eq(m => m.Id, id);
            return (Match)collection.Find(filter);
        }
    }
}
