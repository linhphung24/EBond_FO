namespace EBond_API.Controllers
{
    using EBond_API.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepo;

        public UserController(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        /// <summary>
        /// Get account info of the currently logged-in user.
        /// Custodycd is read from JWT claim — cannot be spoofed.
        /// </summary>
        [HttpGet("info")]
        public async Task<IActionResult> GetInfoCustomer()
        {
            var custodycd = User.FindFirst("username")?.Value;

            if (string.IsNullOrEmpty(custodycd))
                return Forbid();

            try
            {
                var data = await _userRepo.GetAccountAsync(custodycd);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
