using FootballClubBackend.Model;
using FootballClubBackend.Model.DTO;
using FootballClubBackend.Repository;
using FootballClubBackend.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubBackend.Controllers
{
    [ApiController]
    [Route("players")]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _playerService;
        private readonly PlayerStatisticService _playerStatisticService;

        public PlayerController(PlayerService playerService, PlayerStatisticService playerStatisticService)
        {
            _playerService = playerService;
            _playerStatisticService = playerStatisticService;
        }

        [HttpGet("getAll")]
        public ActionResult GetAll()
        {
            return Ok(_playerService.GetAll());
        }

        [HttpGet("getActiveAndLoaned")]
        public ActionResult GetActiveAndLoaned()
        {
            return Ok(_playerService.GetActiveAndLoaned());
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(CreatePlayer dto)
        {
            return _playerService.Create(new Player(dto)) ? Ok(new { message = "Player created successfully" }) : BadRequest(new { message = "Error occurred" });
        }

        [HttpGet("getByName/{name}")]
        [HttpGet("getById/{id}")]
        public ActionResult GetPlayer(string? name, string? id)
        {
            return Ok(_playerService.GetPlayerByNameOrId(name,id));
        }

        [HttpPut("getStatistics")]
        public ActionResult GetStatisticsForPlayer(GetStatisticsForPlayerDto dto)
        {    
            return Ok(_playerStatisticService.GetAllForPlayerBySeasonAndCompetition(dto));
        }

    }
}
