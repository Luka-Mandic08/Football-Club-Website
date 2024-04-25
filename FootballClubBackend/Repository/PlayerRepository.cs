using FootballClubBackend.Model;
using FootballClubBackend.Model.DTO;
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

        public ICollection<Player> GetAll()
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
            return collection.Find(filter).FirstOrDefault();
        }

        public Player GetByName(string name,string surname)
        {
            var filter = Builders<Player>.Filter.And(
                Builders<Player>.Filter.Eq(p => p.Name, name),
                Builders<Player>.Filter.Eq(p => p.Surname, surname));
            return collection.Find(filter).FirstOrDefault();
        }

        public ICollection<Player> GetEligibleForMatch(ICollection<Guid>? squadIds, ICollection<Guid>? subsIds)
        {
            var filter = Builders<Player>.Filter.And(
                Builders<Player>.Filter.Eq(p => p.Status,FirstTeamStatus.Active),
                Builders<Player>.Filter.Nin(p => p.Id, squadIds),
                Builders<Player>.Filter.Nin(p => p.Id, subsIds));
            return collection.Find(filter).ToList();
        }

        public ICollection<Player> GetInMatchSquad(ICollection<Guid>? ids)
        {
            if (ids == null)
            {
                return null;
            }
            var filter =Builders<Player>.Filter.In(p => p.Id, ids);
            return collection.Find(filter).ToList();
        }

        public ICollection<Player> GetAllActive()
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Status, FirstTeamStatus.Active);
            var sortDefinition = Builders<Player>.Sort.Ascending(p => p.Position).Ascending(p => p.SquadNumber);
            return collection.Find(filter).Sort(sortDefinition).ToList();
        }

        public ICollection<Player> GetAllLoaned()
        {
            var filter = Builders<Player>.Filter.Eq(p => p.Status, FirstTeamStatus.OnLoan);
            var sortDefinition = Builders<Player>.Sort.Ascending(p => p.Position).Ascending(p => p.SquadNumber);
            return collection.Find(filter).Sort(sortDefinition).ToList();
        }
    }
}
