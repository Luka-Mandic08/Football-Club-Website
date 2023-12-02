using FootballClubBackend.Helper;
using FootballClubBackend.Model;
using FootballClubBackend.Model.DTO;
using FootballClubBackend.Service;
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
            if (_userService.Register(dto, "user"))
            {
                return Ok(new { message = "Success" });
            }
            return BadRequest(new { message = "Username taken" });
        }

        [HttpPost("register/admin")]
        public ActionResult RegisterAdmin(Register dto) {
            if (Authorizer.CheckAuthorization(Request.Headers.Authorization,"admin"))
            {
                return Unauthorized();
            }
            if (_userService.Register(dto, "admin"))
            {
                return Ok(new { message = "Success" });
            }
            return BadRequest(new { message = "Username taken" });
        }
    }
}
