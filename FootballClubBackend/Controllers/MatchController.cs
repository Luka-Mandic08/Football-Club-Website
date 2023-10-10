using FootballClubBackend.Model.DTO;
using FootballClubBackend.Model;
using FootballClubBackend.Service;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubBackend.Controllers
{
    [ApiController]
    [Route("match")]
    public class MatchController :ControllerBase
    {

        private readonly MatchService _matchService;

        public MatchController(MatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpPost]
        public ActionResult Create(CreateMatch dto)
        {
            return _matchService.Create(dto) ? Ok("Kreiran mec valjda") : BadRequest("Error occurred");
        }
    }

    
}
