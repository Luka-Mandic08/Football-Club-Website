namespace FootballClubBackend.Model
{
    public class News
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<string> Paragraphs { get; set; }
        public ICollection<string> Images { get; set; }
        public DateTime UploadDate { get; set; }
        public Match? Match { get; set; }

    }
}
