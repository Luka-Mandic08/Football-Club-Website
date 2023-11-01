using FootballClubBackend.Model.DTO;
using FootballClubBackend.Model;
using FootballClubBackend.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace FootballClubBackend.Controllers
{
    [ApiController]
    [Route("matches")]
    public class MatchController : ControllerBase
    {

        private readonly MatchService _matchService;

        public MatchController(MatchService matchService)
        {
            _matchService = matchService;
        }

        [HttpPost]
        public ActionResult Create(CreateMatch dto)
        {
            switch (_matchService.Create(dto))
            {
                case "Ok": return Ok("Match created successfully");
                case "Add image": return Ok("Image missing");
                case "Date taken": return BadRequest("Date taken");
                    default: return BadRequest("Something went wrong");
            }
        }

        [HttpGet("fixtures")]
        public ActionResult GetFixtures()
        {
            var fixtures = new List<MatchPreview>();
            foreach (var fixture in _matchService.GetFixtures())
            {
                fixtures.Add(new MatchPreview(fixture, false));
            }

            return Ok(fixtures);
        }

        [HttpGet("results")]
        public ActionResult GetResults()
        {
            var results = new List<MatchPreview>();
            foreach (var result in _matchService.GetResults())
            {
                results.Add(new MatchPreview(result, true));
            }

            return Ok(results);
        }

        [HttpGet("{id}")]
        public ActionResult GetMatch(string id)
        {
            var guid = Guid.Parse(id);
            return Ok(_matchService.GetById(guid));
        }
        
        [HttpGet("getByDate/{date:datetime}")]
        public ActionResult GetMatchByDate(DateTime date)
        {
            return Ok(_matchService.GetByDate(date));
        }

        [HttpPut("update/matchevents/{id}")]
        public ActionResult UpdateMatchEvents(string id,ICollection<MatchEvent> events)
        {
            var guid = Guid.Parse(id);
            Match updatedMatch = _matchService.UpdateMatchEvents(guid, events);
            if (updatedMatch != null)
            {
                return Ok(updatedMatch);
            }
            return BadRequest("Unable to update match events");
        }
        
    }
}

