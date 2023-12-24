using FootballClubBackend.Model;
using FootballClubBackend.Model.Enums;
using FootballClubBackend.Repository;

namespace FootballClubBackend.Service
{
    public class ArticleService
    {
        private readonly ArticleRepository _articleRepository;

        public ArticleService(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void Create(Article article)
        {
            _articleRepository.Create(article);
        }

        public Article GetById(string id)
        {
            return _articleRepository.GetById(Guid.Parse(id));
        }

        public ICollection<Article> GetAllByType(int type)
        {
            return _articleRepository.GetAllByType((ArticleType)type);
        }

        public ICollection<Article> GetAllForMatch(string matchId)
        {
            return _articleRepository.GetAllForMatch(matchId);
        }

        public ICollection<Article> GetAllForPlayer(string playerId)
        {
            return _articleRepository.GetAllForPlayer(playerId);
        }
    }
}
