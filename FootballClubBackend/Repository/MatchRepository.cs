﻿using FootballClubBackend.Model;
using FootballClubBackend.Model.DTO;
using FootballClubBackend.Model.Statistics;
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

        public void Create(Match match)
        {
            match.Id = Guid.NewGuid();
            collection.InsertOne(match);
        }

        public ICollection<Match> GetFixtures()
        {
            var filter = Builders<Match>.Filter.Gte(m => m.Start, DateTime.Now);
            var sortDefinition = Builders<Match>.Sort.Ascending(m => m.Start);
            return collection.Find(filter).Sort(sortDefinition).ToList();
        }

        public ICollection<Match> GetResults()
        {
            var filter = Builders<Match>.Filter.Lte(m => m.Start, DateTime.Now);
            var sortDefinition = Builders<Match>.Sort.Descending(m => m.Start);
            return collection.Find(filter).Sort(sortDefinition).ToList();
        }

        public Match GetById(Guid id)
        {
            var filter = Builders<Match>.Filter.Eq(m => m.Id, id);
            return collection.Find(filter).FirstOrDefault();
        }

        public Match? GetByDate(DateTime start)
        {
            var helperDateFrom = start.Date;
            var helperDateTo = helperDateFrom.AddDays(1);
            var matchFilter = Builders<Match>.Filter.And(Builders<Match>.Filter.Gte(m => m.Start, helperDateFrom),
                Builders<Match>.Filter.Lte(m => m.Start, helperDateTo)
            );
            return collection.Find(matchFilter).FirstOrDefault();
        }

        public Match UpdateMatchEvents(Guid id, ICollection<MatchEvent> events)
        {
            var filter = Builders<Match>.Filter.Eq(m => m.Id, id);
            var update = Builders<Match>.Update.Set(m => m.MatchEvents, events);
            var options = new FindOneAndUpdateOptions<Match>{ ReturnDocument = ReturnDocument.After };
            return collection.FindOneAndUpdate(filter, update, options);
        }
        public Match UpdateMatchSquads(Guid id, List<string>? squad, List<string>? subs, ICollection<PlayerForSquad>? oppositionSquad, ICollection<PlayerForSquad>? oppositionSubs)
        {
            List<Guid> squadGuidList = squad.Select(Guid.Parse).ToList();
            List<Guid> subsGuidList = subs.Select(Guid.Parse).ToList();
            var filter = Builders<Match>.Filter.Eq(m => m.Id, id);
            var update = Builders<Match>.Update.Set(m => m.SquadIds, squadGuidList).Set(m => m.SubsIds, subsGuidList).Set(m=>m.OpponentSquad,oppositionSquad).Set(m => m.OpponentSubs, oppositionSubs);
            var options = new FindOneAndUpdateOptions<Match> { ReturnDocument = ReturnDocument.After };
            return collection.FindOneAndUpdate(filter, update, options);
        }

        public Match UpdateMatchStatistics(Guid id, MatchStatistics? statistics, MatchStatistics? opponentStatistics)
        {
            var filter = Builders<Match>.Filter.Eq(m => m.Id, id);
            var update = Builders<Match>.Update.Set(m => m.Statistics, statistics).Set(m => m.OpponentStatistics, opponentStatistics);
            var options = new FindOneAndUpdateOptions<Match> { ReturnDocument = ReturnDocument.After };
            return collection.FindOneAndUpdate(filter, update, options);
        }
    }
}