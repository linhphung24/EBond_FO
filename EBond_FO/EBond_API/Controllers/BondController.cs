namespace EBond_API.Controllers
{
    using EBond_API.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BondController : ControllerBase
    {
        private readonly BondRepository _repo;

        public BondController(BondRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Get all corporate bond info.
        /// Optional filters (accent-insensitive): ?symbol=AAA  ?name=ngan hang
        /// Pass null or "" to skip a filter.
        /// </summary>
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? symbol = null,
            [FromQuery] string? name   = null)
        {
            try
            {
                var data = await _repo.GetAllAsync(symbol, name);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
