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

        public async Task<IActionResult> Index()
        {
            var accessToken = HttpContext.Session.GetString("AccessToken");

            // Redirect to login if not authenticated
            if (string.IsNullOrEmpty(accessToken))
                return RedirectToAction("Index", "Login");

            _http.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var res = await _http.GetAsync("/api/bond/getall");

            if (!res.IsSuccessStatusCode)
                return View(Enumerable.Empty<IFG_Corporate_Bond_Info>());

            var list = await res.Content.ReadFromJsonAsync<List<IFG_Corporate_Bond_Info>>(
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                ?? new List<IFG_Corporate_Bond_Info>();

            return View(list);
        }
    }
}
