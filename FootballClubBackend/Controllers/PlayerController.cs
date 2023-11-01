using FootballClubBackend.Model;
using FootballClubBackend.Model.DTO;
using FootballClubBackend.Repository;
using FootballClubBackend.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubBackend.Controllers
{
    [ApiController]
    [Route("players")]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public PlayerController(PlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet()]
        public ActionResult GetAll()
        {
            return Ok(_playerService.GetAll());
        }

        [HttpPost]
        public ActionResult Create(CreatePlayer dto)
        {
            return _playerService.Create(new Player(dto)) ? Ok("Kreiran valjda") : BadRequest("Error occurred");
        }

        /*
        [HttpGet("getById/{id}")]
        public ActionResult GetById(string id)
        {
            PlayerWithStatistics? player = _playerService.GetById(id);
            return player != null ? Ok(player) : BadRequest("Could not find player with requested id");
        }*/

        [HttpPut("updateStatistics/{id}")]
        public ActionResult UpdateStatistics(UpdateStatistics updateStatistics)
        {
            return Ok();
        }
    }
}
