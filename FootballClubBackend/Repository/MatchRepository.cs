using FootballClubBackend.Model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FootballClubBackend.Repository
{
    public class MatchRepository
    {
        private readonly IMongoCollection<Match> collection;
        private readonly IMongoDatabase database;

        public MatchRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("FootballClubDb");
            collection = database.GetCollection<Match>("Matches");
        }

        public bool Create(Match match)
        {
            match.Id = Guid.NewGuid();
            collection.InsertOne(match);
            var matchCollection = database.GetCollection<Team>("Teams");
            var filter = Builders<Team>.Filter.Eq(t => t.Name, match.Opponent);
            if (!matchCollection.Find(filter).Any())
            {
                matchCollection.InsertOne(new Team(match.Opponent));
                return false;
            }
            return true;
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
