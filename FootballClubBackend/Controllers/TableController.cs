using FootballClubBackend.Model;
using FootballClubBackend.Model.DTO;
using FootballClubBackend.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubBackend.Controllers
{
    [ApiController]
    [Route("tables")]
    public class TableController : ControllerBase
    {
        private readonly TableService _tableService;

        public TableController(TableService tableService)
        {
            _tableService = tableService;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(CreateTable dto)
        {
            _tableService.Create(dto);
            return Ok(_tableService.GetAllBySeason(-1));
        }

        [HttpGet("{season}")]
        public ActionResult GetAllBySeason(int season)
        {
            return Ok(_tableService.GetAllBySeason(season));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPut]
        public ActionResult Update(Table table)
        {
            _tableService.Update(table);
            return Ok(_tableService.GetAllBySeason(-1));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            _tableService.Delete(id);
            return Ok(_tableService.GetAllBySeason(-1));
        }

    }
}
