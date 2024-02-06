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

        public ICollection<Article> GetByType(ArticleType type,int page)
        {
            var filter = Builders<Article>.Filter.And(
                Builders<Article>.Filter.Lte(a => a.UploadDate, DateTime.Now),
                Builders<Article>.Filter.Eq(a => a.ArticleType, type));
            var sortDefinition = Builders<Article>.Sort.Descending(a => a.UploadDate);
            return collection.Find(filter).Sort(sortDefinition).Skip(10*(page-1)).Limit(10).ToList();
        }

        public ICollection<Article> GetAllForMatch(string matchId)
        {
            var filter = Builders<Article>.Filter.And(
                Builders<Article>.Filter.Lte(a => a.UploadDate, DateTime.Now),
                Builders<Article>.Filter.Eq(a => a.MatchId, matchId));
            var sortDefinition = Builders<Article>.Sort.Descending(a => a.UploadDate);
            return collection.Find(filter).Sort(sortDefinition).ToList();
        }

        public ICollection<Article> GetAllForPlayer(string playerId)
        {
            var filter = Builders<Article>.Filter.And(
                Builders<Article>.Filter.Lte(a => a.UploadDate, DateTime.Now),
                Builders<Article>.Filter.AnyEq(a => a.PlayerIds, playerId));

            var sortDefinition = Builders<Article>.Sort.Descending(a => a.UploadDate);

            return collection.Find(filter).Sort(sortDefinition).Limit(5).ToList();
        }



        public ICollection<Article> GetForHomePage()
        {
            var filter = Builders<Article>.Filter.And(
                Builders<Article>.Filter.Lte(a => a.UploadDate, DateTime.Now),
                Builders<Article>.Filter.Eq(a => a.ArticleType, ArticleType.News));
            var sortDefinition = Builders<Article>.Sort.Descending(a => a.UploadDate);
            return collection.Find(filter).Sort(sortDefinition).Limit(7).ToList();
        }
    }
}
