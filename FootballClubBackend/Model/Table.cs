using FootballClubBackend.Model.DTO;
using System.ComponentModel.DataAnnotations;

namespace FootballClubBackend.Model
{
    public class Table
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Competition { get; set; }
        [Required]
        public int Season { get; set; }
        public ICollection<TableRow> Rows { get; set; }

        public Table(CreateTable dto)
        {
            Competition = dto.Competition;
            Season = dto.Season;
            Rows = dto.Rows;
            foreach (TableRow row in Rows)
            {
                row.Id = Guid.NewGuid();
            }
        }

        public Table() { }
    }


    public class TableRow
    {
        public Guid? Id { get; set; }

        [Required]
        public int Position { get; set; }

        [Required]
        public string Team { get; set; }

        [Required]
        public int Wins { get; set; }
        [Required]
        public int Draws { get; set; }
        [Required]
        public int Losses { get; set; }
        [Required]
        public int GoalDifference { get; set; }
        [Required]
        public int Points { get; set; }
    }
}
