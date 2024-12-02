using Microsoft.AspNetCore.Mvc;
using TaskManagementSystemData.Entities;
using TaskManagementSystemService.Interfaces;

namespace TaskManagementSystem.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public ActionResult<LoginResponse> Login([FromBody] UserDto user)
        {
            if (user.Username == "admin" && user.Password == "password123")
            {
                var token = _tokenService.GenerateToken(user.Username);
                var response = new LoginResponse
                {
                    Token = token
                };
                return Ok(response); 
            }

            return Unauthorized("Invalid credentials");
        }
    }

    public class LoginResponse
    {
        public string Token { get; set; }
    }
}
