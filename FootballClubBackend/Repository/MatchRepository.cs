using FootballClubBackend.Model;
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
            var sortDefinition = Builders<Match>.Sort.Ascending(m => m.Start);
            return collection.Find(filter).Sort(sortDefinition).ToList();
        }

        public IEnumerable<Match> GetResults()
        {
            var filter = Builders<Match>.Filter.Ne(m => m.Statistics, null);
            var sortDefinition = Builders<Match>.Sort.Descending(m => m.Start);
            return collection.Find(filter).Sort(sortDefinition).ToList();
        }

        public Match GetById(Guid id)
        {
            var filter = Builders<Match>.Filter.Eq(m => m.Id, id);
            return (Match)collection.Find(filter);
        }

        public Match? GetByDate(DateTime start)
        {
            var helperDateFrom = start.Date;
            var helperDateTo = helperDateFrom.AddDays(1);
            var matchFilter = Builders<Match>.Filter.And(Builders<Match>.Filter.Gte(m => m.Start, helperDateFrom),
                Builders<Match>.Filter.Lte(m => m.Start, helperDateTo)
            );
            return collection.Find(matchFilter).First();
        }

        public Match UpdateMatchEvents(Guid id, ICollection<MatchEvent> events)
        {
            var filter = Builders<Match>.Filter.Eq(m => m.Id, id);
            var update = Builders<Match>.Update.Set(m => m.MatchEvents, events);
            var options = new FindOneAndUpdateOptions<Match>{ ReturnDocument = ReturnDocument.After };
            return collection.FindOneAndUpdate(filter, update, options);
        }
    }
}