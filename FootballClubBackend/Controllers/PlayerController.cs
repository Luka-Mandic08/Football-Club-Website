using FootballClubBackend.Model;
using FootballClubBackend.Repository;
using FootballClubBackend.Service;
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
        public ActionResult Create()
        {
            _playerService.Create(new Player("Marko", "Markovic"));
            return Ok("Kreiran valjda");
        }
    }
}
