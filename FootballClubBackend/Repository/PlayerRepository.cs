using FootballClubBackend.Model;
using FootballClubBackend.Model.Enums;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Text.RegularExpressions;
using static MongoDB.Driver.WriteConcern;

namespace FootballClubBackend.Repository
{
    public class PlayerRepository
    {
        private readonly IMongoCollection<Player> collection;

        public PlayerRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("FootballClubDb");
            collection = database.GetCollection<Player>("Players");
        }

        public IEnumerable<Player> GetAll()
        {
            var filter = Builders<Player>.Filter.Empty;
            return collection.Find(filter).ToList();

        }

        public void Create(Player player)
        {
            player.Id = Guid.NewGuid();
            collection.InsertOne(player);
            return;
        }

        public bool CheckSquadNumberAvailability(int squadNumber)
        {
            var filter = Builders<Player>.Filter.And(
                Builders<Player>.Filter.Eq(p => p.SquadNumber, squadNumber),
                Builders<Player>.Filter.Ne(p => (int)p.Status, 1)
            );
            return collection.Find(filter).Any();
        }

        public Player GetById(Guid id)
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Id, id);
            return collection.Find(filter).First();
        }
    }
}
