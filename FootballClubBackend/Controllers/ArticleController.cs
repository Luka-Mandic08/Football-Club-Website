using FootballClubBackend.Model.DTO;
using FootballClubBackend.Model;
using FootballClubBackend.Service;
using Microsoft.AspNetCore.Mvc;
using FootballClubBackend.Model.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace FootballClubBackend.Controllers
{
    [ApiController]
    [Route("articles")]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleService _articleService;

        public ArticleController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(CreateArticle dto)
        {
            _articleService.Create(new Article(dto));
            return Ok(new {message = "Article successfully created"});
        }

        [HttpGet("getById/{id}")]
        public ActionResult GetById(string id)
        {
            return Ok(_articleService.GetById(id));
        }

        [HttpGet("getByType/{type}/{page}")]
        public ActionResult GetAllByType(int type,int page)
        {
            return Ok(_articleService.GetByType(type, page));
        }

        [HttpGet("getForMatch/{matchId}")]
        public ActionResult GetAllForMatch(string matchId)
        {
            return Ok(_articleService.GetAllForMatch(matchId));
        }

        [HttpGet("getForPlayer/{playerId}")]
        public ActionResult GetAllForPlayer(string playerId)
        {
            return Ok(_articleService.GetAllForPlayer(playerId));
        }

        [HttpGet("getForHomePage")]
        public ActionResult GetForHomePage()
        {
            return Ok(_articleService.GetForHomePage());
        }
        
    }
}
