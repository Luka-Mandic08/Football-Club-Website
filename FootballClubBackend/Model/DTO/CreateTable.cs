using System.ComponentModel.DataAnnotations;

namespace FootballClubBackend.Model.DTO
{
    public class CreateTable
    {
        [Required]
        public string Competition { get; set; }
        [Required]
        public int Season { get; set; }
        public ICollection<TableRow> Rows { get; set; }
    }
}
