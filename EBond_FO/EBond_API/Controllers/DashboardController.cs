namespace EBond_API.Controllers
{
    using EBond_API.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly BondRepository    _bondRepo;
        private readonly MCCodeRepository  _mcCodeRepo;

        public DashboardController(BondRepository bondRepo, MCCodeRepository mcCodeRepo)
        {
            _bondRepo   = bondRepo;
            _mcCodeRepo = mcCodeRepo;
        }

        /// <summary>
        /// Get corporate bond info with optional filters.
        /// Pass null or "" to skip a filter (returns all).
        /// </summary>
        [HttpGet("bond/getall")]
        public async Task<IActionResult> GetBondAll(
            [FromQuery] string? symbol                = null,
            [FromQuery] string? name                  = null,
            [FromQuery] int?    securityTradingStatus = null)
        {
            try
            {
                var data = await _bondRepo.GetAllAsync(symbol, name, securityTradingStatus);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Get SecurityTradingStatus list for filter dropdown.
        /// </summary>
        [HttpGet("mccode/security-trading-status")]
        public async Task<IActionResult> GetSecurityTradingStatus()
        {
            try
            {
                var data = await _mcCodeRepo.GetSecurityTradingStatusAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
