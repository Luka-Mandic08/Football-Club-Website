using FootballClubBackend.Model;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace FootballClubBackend.Repository
{
    public class TableRepository
    {
        private readonly IMongoCollection<Table> collection;
        private readonly IMongoDatabase database;

        public TableRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("FootballClubDb");
            collection = database.GetCollection<Table>("Tables");
        }

        public void Create(Table table)
        {
            table.Id = Guid.NewGuid();
            collection.InsertOne(table);
        }

        public ICollection<Table> GetAllBySeason(int season)
        {
            var filter = Builders<Table>.Filter.Eq(t => t.Season, season);
            return collection.Find(filter).ToList();
        }

        public void Update(Table table)
        {
            var filter = Builders<Table>.Filter.Eq(t => t.Id, table.Id);
            var update = Builders<Table>.Update.Set(t => t.Rows, table.Rows);
            collection.FindOneAndUpdate(filter, update);
        }

        public void Delete(Guid id)
        {
            var filter = Builders<Table>.Filter.Eq(t => t.Id, id);
            collection.FindOneAndDelete(filter);
        }
    }
}
