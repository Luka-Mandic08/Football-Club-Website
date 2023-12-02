using FootballClubBackend.Model.DTO;
using FootballClubBackend.Model;
using FootballClubBackend.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using FootballClubBackend.Model.Statistics;
using FootballClubBackend.Helper;

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
                case "Ok": return Ok(new { message = "Match created successfully" });
                case "Add image": return Ok(new { message = "Image missing" });
                case "Date taken": return BadRequest(new { message = "Date taken" });
                    default: return BadRequest(new { message = "Something went wrong" });
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

        [HttpGet("matchevents/{id}")]
        public ActionResult GetMatchEvents(string id)
        {
            var guid = Guid.Parse(id);
            return Ok(_matchService.GetMatchEvents(guid));
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
            return BadRequest(new { message = "Unable to update match events" });
        }

        [HttpGet("squads/{id}")]
        public ActionResult GetSquads(string id)
        {
            var guid = Guid.Parse(id);
            return Ok(_matchService.GetMatchSquads(guid));
        }

        [HttpPut("update/squads/{id}")]
        public ActionResult UpdateSquads(string id, Squads squads)
        {
            var guid = Guid.Parse(id);
            Squads updatedSquads = _matchService.UpdateMatchSquads(guid, squads);
            if (updatedSquads != null)
            {
                return Ok(updatedSquads);
            }
            return BadRequest(new { message = "Unable to update match events" });
        }

        [HttpGet("statistics/{id}")]
        public ActionResult GetStatistics(string id)
        {
            //if (!Authorizer.CheckAuthorization(Request.Headers.Authorization, "any"))
                //return BadRequest(new { message = "no token" });
            var guid = Guid.Parse(id);
            return Ok(_matchService.GetMatchStatistics(guid));
        }

        [HttpPut("update/statistics/{id}")]
        public ActionResult UpdateStatistics(string id, MatchStatisticsDto statistics)
        {
            var guid = Guid.Parse(id);
            Match updatedMatch = _matchService.UpdateMatchStatistics(guid, statistics);
            if (updatedMatch != null)
            {
                return Ok(statistics);
            }
            return BadRequest(new { message = "Unable to update match events" });
        }

    }
}

