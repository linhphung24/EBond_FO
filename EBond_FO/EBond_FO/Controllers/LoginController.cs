using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EBond_FO.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _http;

        public LoginController(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("API");
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("AccessToken")))
                return RedirectToAction("Index", "DashBoard");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            var res = await _http.PostAsJsonAsync("/api/auth/login", new { username, password });

            if (!res.IsSuccessStatusCode)
            {
                var err = await res.Content.ReadFromJsonAsync<JsonElement>();
                ViewBag.Error = err.TryGetProperty("message", out var msg)
                    ? msg.GetString()
                    : "Đăng nhập thất bại";
                return View();
            }

            var token = await res.Content.ReadFromJsonAsync<JsonElement>();
            HttpContext.Session.SetString("AccessToken",  token.GetProperty("accessToken").GetString()!);
            HttpContext.Session.SetString("RefreshToken", token.GetProperty("refreshToken").GetString()!);

            return RedirectToAction("Index", "DashBoard");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
