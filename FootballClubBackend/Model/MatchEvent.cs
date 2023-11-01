using System.ComponentModel.DataAnnotations;

namespace FootballClubBackend.Model
{
    public class MatchEvent
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Text { get; set; }

        [Required]
        public string Minute { get; set; }

        public bool IsBefore(MatchEvent matchEvent)
        {
            var firstTimeParts = this.Minute.Split('+');
            var secondTimeParts = matchEvent.Minute.Split("+");
            if(firstTimeParts.Length == 1)
            {
                return int.Parse(firstTimeParts[0]) <= int.Parse(secondTimeParts[0]);
            }
            else if(secondTimeParts.Length == 1)
            {
                return int.Parse(firstTimeParts[0]) < int.Parse(secondTimeParts[0]);
            }
            else if(int.Parse(firstTimeParts[0]) == int.Parse(secondTimeParts[0]))
            {
                return int.Parse(firstTimeParts[1]) <= int.Parse(secondTimeParts[1]);
            }
            else
            {
                return int.Parse(firstTimeParts[0]) < int.Parse(secondTimeParts[0]);
            }
        }
    }
}
