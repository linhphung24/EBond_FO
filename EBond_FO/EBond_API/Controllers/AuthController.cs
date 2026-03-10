using EBond_API.DTO;
using EBond_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EBond_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "";
                var result = await _authService.Login(request, ip);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new
                {
                    message = ex.Message,
                    detail  = ex.InnerException?.Message
                });
            }
        }

        // POST api/auth/hashgen  ← temporary endpoint, remove after use
        // Body: "plain_text_password"
        [HttpPost("hashgen")]
        public IActionResult HashGen([FromBody] string password)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(password, workFactor: 11);
            return Ok(new { password, hash });
        }

        // POST api/auth/refresh
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] string refreshToken)
        {
            try
            {
                var result = await _authService.Refresh(refreshToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
