using FootballClubBackend.Helper;
using FootballClubBackend.Model;
using MongoDB.Driver;

namespace FootballClubBackend.Repository
{
    public class UserRepository
    {
        private readonly IMongoCollection<User> collection;
        private readonly IMongoDatabase database;

        public UserRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("FootballClubDb");
            collection = database.GetCollection<User>("Users");
        }

        public User? GetByEmail(string email)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Email, email);
            return collection.Find(filter).Any()? collection.Find(filter).First():null;
        }

        public bool Create(User user)
        {
            if (GetByEmail(user.Email) != null)
                return false;
            user.Id = Guid.NewGuid();
            user.Password = PasswordHasher.HashPassword(user.Password);
            collection.InsertOne(user);
            return true;
        }

        public string? Login(string username, string password)
        {
            User? user = GetByEmail(username);
            if (user == null) 
                return null;
            if(!PasswordHasher.VerifyPassword(password, user.Password)) 
                return null;
            return user.Role;
        }

    }
}
