using EBond_FO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EBond_FO.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly HttpClient _http;

        public DashBoardController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("API");
        }

        public async Task<IActionResult> Index(string keyword, string securityTradingStatus)
        {
            var accessToken = HttpContext.Session.GetString("AccessToken");

            // Redirect to login if not authenticated
            if (string.IsNullOrEmpty(accessToken))
                return RedirectToAction("Index", "Login");

            _http.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            // Lấy danh sách tất cả các trạng thái
            var status = await _http.GetAsync("/api/Dashboard/mccode/security-trading-status");

            var listStatus = new List<MCCode>();

            if (status.IsSuccessStatusCode)
            {
                listStatus = await status.Content.ReadFromJsonAsync<List<MCCode>>(
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                    ?? new List<MCCode>();
            }

            // Lấy danh sách các trạng thái để tạo dropdown
            ViewBag.AllStatus = listStatus;

            // Build query string
            var url = "/api/Dashboard/bond/getall";

            var query = new List<string>();

            if (!string.IsNullOrEmpty(keyword))
            {
                query.Add($"search={keyword}");
            }

            if (!string.IsNullOrEmpty(securityTradingStatus))
                query.Add($"securityTradingStatus={securityTradingStatus}");

            if (query.Any())
                url += "?" + string.Join("&", query);

            var res = await _http.GetAsync(url);

            if (!res.IsSuccessStatusCode)
                return View(Enumerable.Empty<IFG_Corporate_Bond_Info>());

            var list = await res.Content.ReadFromJsonAsync<List<IFG_Corporate_Bond_Info>>(
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                ?? new List<IFG_Corporate_Bond_Info>();


            // Map status text
            foreach (var bond in list)
            {
                var statusMatch = listStatus
                    .FirstOrDefault(x => x.ID == bond.SecurityTradingStatus?.ToString());

                if (statusMatch != null)
                {
                    bond.SecurityTradingStatusText = statusMatch.Description;
                }
            }


            return View(list);
        }
    }
}
