using FootballClubBackend.Model;
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
        public ActionResult Create()
        {
            string[] myStringArray = {"Premier league", "FA cup"};
            bool success = _playerService.Create(new Player("Marko", "Markovic",new DateTime(2000,8,28),"Belgrade, Serbia",0,Model.Enums.Position.Attacker,9,0,DateTime.Now,"image string"), myStringArray);
            return success?Ok("Kreiran valjda"):BadRequest("Error occurred");
        }

        [HttpGet("getById/{id}")]
        public ActionResult GetById()
        {
            string[] myStringArray = { "Premier league", "FA cup" };
            bool success = _playerService.Create(new Player("Marko", "Markovic", new DateTime(2000, 8, 28), "Belgrade, Serbia", 0, Model.Enums.Position.Attacker, 9, 0, DateTime.Now, "image string"), myStringArray);
            return success ? Ok("Kreiran valjda") : BadRequest("Error occurred");
        }
    }
}
