using System.ComponentModel.DataAnnotations;

namespace FootballClubBackend.Model.DTO
{
    public class GetStatisticsForPlayerDto
    {
        public string? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Competition {  get; set; }
        [Required]
        public int Season { get; set; }

        public GetStatisticsForPlayerDto() { }
    }

}
