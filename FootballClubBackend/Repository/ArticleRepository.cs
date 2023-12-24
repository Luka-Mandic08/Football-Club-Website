using FootballClubBackend.Model;
using FootballClubBackend.Model.Enums;
using MongoDB.Driver;

namespace FootballClubBackend.Repository
{
    public class ArticleRepository
    {
        private readonly IMongoCollection<Article> collection;
        private readonly IMongoDatabase database;

        public ArticleRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("FootballClubDb");
            collection = database.GetCollection<Article>("Articles");
        }

        public void Create(Article article)
        {
            article.Id = Guid.NewGuid();
            collection.InsertOne(article);
        }

        public Article GetById(Guid id)
        {
            var filter = Builders<Article>.Filter.Eq(a => a.Id, id);
            return collection.Find(filter).FirstOrDefault();
        }

        public ICollection<Article> GetAllByType(ArticleType type)
        {
            var filter = Builders<Article>.Filter.And(
                Builders<Article>.Filter.Lte(a => a.UploadDate, DateTime.Now),
                Builders<Article>.Filter.Eq(a => a.ArticleType, type));
            return collection.Find(filter).ToList();
        }

        public ICollection<Article> GetAllForMatch(string matchId)
        {
            var filter = Builders<Article>.Filter.And(
                Builders<Article>.Filter.Lte(a => a.UploadDate, DateTime.Now),
                Builders<Article>.Filter.Eq(a => a.MatchId, matchId));
            return collection.Find(filter).ToList();
        }

        public ICollection<Article> GetAllForPlayer(string playerId)
        {
            var filter = Builders<Article>.Filter.And(
                Builders<Article>.Filter.Lte(a => a.UploadDate, DateTime.Now),
                Builders<Article>.Filter.ElemMatch(a => a.PlayerIds, Builders<string>.Filter.Eq(s => s, playerId)));
            return collection.Find(filter).ToList();
        }
    }
}
