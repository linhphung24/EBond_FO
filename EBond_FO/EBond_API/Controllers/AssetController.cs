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
        private readonly AssetRepository _repo;

        public AssetController(AssetRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Get asset quantity of the currently logged-in user.
        /// Custodycd is read from JWT claim — cannot be spoofed.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAssetByCustomer()
        {
            // Username = custodycd, read from JWT claim
            var custodycd = User.FindFirst("username")?.Value;

            if (string.IsNullOrEmpty(custodycd))
                return Forbid(); // Token does not contain a custodycd

            try
            {
                var data = await _repo.GetAssetByCustomerAsync(custodycd);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
