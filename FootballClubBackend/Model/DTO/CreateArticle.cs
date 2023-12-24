using FootballClubBackend.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace FootballClubBackend.Model
{
    public class CreateArticle
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public ICollection<Section> Paragraphs { get; set; }
        [Required]
        public DateTime UploadDate { get; set; }
        [Required]
        public ArticleType ArticleType { get; set; }
        public string? MatchId { get; set; }
        public ICollection<string>? PlayerIds { get; set; }
    }
}
