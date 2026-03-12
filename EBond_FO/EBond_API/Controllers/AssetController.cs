namespace EBond_API.Controllers
{
    using EBond_API.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AssetController : ControllerBase
    {
        private readonly AssetRepository   _assetRepo;

        public AssetController(AssetRepository assetRepo)
        {
            _assetRepo   = assetRepo;
        }

        /// <summary>
        /// Get asset quantity of the currently logged-in user.
        /// Custodycd is read from JWT claim — cannot be spoofed.
        /// </summary>
        [HttpGet("bond")]
        public async Task<IActionResult> GetAssetByCustomer()
        {
            var custodycd = User.FindFirst("username")?.Value;

            if (string.IsNullOrEmpty(custodycd))
                return Forbid();

            try
            {
                var data = await _assetRepo.GetAssetByCustomerAsync(custodycd);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Get cash balance of the currently logged-in user.
        /// Custodycd is read from JWT claim — cannot be spoofed.
        /// </summary>
        [HttpGet("cash")]
        public async Task<IActionResult> GetBalance()
        {
            var custodycd = User.FindFirst("username")?.Value;

            if (string.IsNullOrEmpty(custodycd))
                return Forbid();

            try
            {
                var data = await _assetRepo.GetBalanceAsync(custodycd);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
