using FootballClubBackend.Model.DTO;
using FootballClubBackend.Model;
using FootballClubBackend.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using FootballClubBackend.Model.Statistics;
using FootballClubBackend.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FootballClubBackend.Controllers
{
    [ApiController]
    [Route("matches")]
    public class MatchController : ControllerBase
    {

        private readonly MatchService _matchService;
        private readonly PlayerStatisticService _playerStatisticsService;

        public MatchController(MatchService matchService, PlayerStatisticService playerStatisticsService)
        {
            _matchService = matchService;
            _playerStatisticsService = playerStatisticsService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(CreateMatch dto)
        {
            switch (_matchService.Create(dto))
            {
                case "Ok": return Ok(new { message = "Match created successfully" });
                case "Date taken": return BadRequest(new { message = "Date taken" });
                    default: return BadRequest(new { message = "Something went wrong" });
            }
        }

        [HttpGet("fixtures/{competition}")]
        public ActionResult GetFixtures(string competition,int year)
        {
            var fixtures = new List<MatchPreview>();
            foreach (var fixture in _matchService.GetFixtures(competition))
            {
                fixtures.Add(new MatchPreview(fixture));
            }

            return Ok(fixtures);
        }

        [HttpGet("results/{competition}/{year}")]
        public ActionResult GetResults(string competition, int year)
        {
            var results = new List<MatchPreview>();
            foreach (var result in _matchService.GetResults(competition, year))
            {
                results.Add(new MatchPreview(result));
            }

            return Ok(results);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpGet("getForNewArticle")]
        public ActionResult GetMatch()
        {
            return Ok(_matchService.GetForNewArticle());
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
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
            var guid = Guid.Parse(id);
            return Ok(_matchService.GetMatchStatistics(guid));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
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

        [HttpGet("playerstatistics/{id}")]
        public ActionResult GetPlayerStatistics(string id)
        {
            var guid = Guid.Parse(id);
            return Ok(_playerStatisticsService.GetAllForMatch(guid));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPut("update/playerstatistics")]
        public ActionResult UpdatePlayerStatistics(PlayerStatistic statistics)
        {     
            return Ok(_playerStatisticsService.Create(statistics));
        }

    }
}

