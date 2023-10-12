using FootballClubBackend.Model.DTO;
using FootballClubBackend.Model;
using FootballClubBackend.Service;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubBackend.Controllers
{
    [ApiController]
    [Route("matches")]
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

        [HttpGet("fixtures")]
        public ActionResult GetFixtures()
        {
            List<MatchPreview> fixtures = new List<MatchPreview>();
            foreach(var fixture in _matchService.GetFixtures())
            {
                fixtures.Add(new MatchPreview(fixture,false));
            }
            return Ok(fixtures);
        }

        [HttpGet("results")]
        public ActionResult GetResults()
        {
            List<MatchPreview> results = new List<MatchPreview>();
            foreach (var result in _matchService.GetResults())
            {
                results.Add(new MatchPreview(result,true));
            }
            return Ok(results);
        }

        [HttpGet("{id}")]
        public ActionResult GetMatch(string id)
        {
            Guid guid = Guid.Parse(id);
            return Ok(_matchService.GetMatch(guid));
        }
    }

    
}
