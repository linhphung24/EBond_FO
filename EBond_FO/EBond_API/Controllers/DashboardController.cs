namespace EBond_API.Controllers
{
    using EBond_API.Data;
    using EBond_API.Hub;
    using EBond_API.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SignalR;

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly BondRepository    _bondRepo;
        private readonly MCCodeRepository  _mcCodeRepo;
        private readonly IHubContext<OrderHub> _hubContext;
        public DashboardController(BondRepository bondRepo, MCCodeRepository mcCodeRepo, IHubContext<OrderHub> hub)
        {
            _bondRepo   = bondRepo;
            _mcCodeRepo = mcCodeRepo;
            _hubContext = hub;
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
                //OrderModels order = new OrderModels { custodycd = "040P888888", id = 1, oodstatus = "a" };
                //NotificationService notification = new NotificationService(_hubContext);
                //await notification.NotifyOrderUpdate(order);
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
