using FootballClubBackend.Helper;
using FootballClubBackend.Model;
using FootballClubBackend.Model.DTO;
using FootballClubBackend.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FootballClubBackend.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(Login dto)
        {
            string role = _userService.Login(dto);
            if (role != null)
            {
                var token = Authorizer.GenerateToken(dto.Email, role);
                return Ok(new { token });
            }
            return BadRequest(new { message = "Bad credentials"});
        }

        [HttpPost("register/user")]
        public ActionResult RegisterUser(Register dto)
        {
            if (_userService.Register(dto, "User"))
            {
                return Ok(new { message = "Success" });
            }
            return BadRequest(new { message = "Username taken" });
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [HttpPost("register/admin")]
        public ActionResult RegisterAdmin(Register dto) {
            if (_userService.Register(dto, "Admin"))
            {
                return Ok(new { message = "Success" });
            }
            return BadRequest(new { message = "Username taken" });
        }
    }
}
