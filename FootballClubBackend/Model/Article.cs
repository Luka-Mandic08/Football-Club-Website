using FootballClubBackend.Model.Enums;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace FootballClubBackend.Model
{
    public class Article
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public ICollection<Section> Paragraphs { get; set; }
        [Required]
        public DateTime UploadDate { get; set; }
        [Required]
        public ArticleType ArticleType { get; set; }
        public string? MatchId { get; set; }
        public ICollection<string> PlayerIds { get; set; }


        public Article(CreateArticle dto)
        {
            Title = dto.Title;
            Paragraphs = dto.Paragraphs;
            UploadDate = dto.UploadDate;
            ArticleType = dto.ArticleType;
            MatchId = dto.MatchId;
            PlayerIds = dto.PlayerIds != null ? dto.PlayerIds : new List<string>();
        }
    }

    public class Section
    {
        public string Content { get; set; }
        public SectionType SectionType { get; set; }
    }
}
