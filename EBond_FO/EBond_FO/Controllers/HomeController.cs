using EBond_FO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace EBond_FO.Controllers
{
    public class HomeController : Controller
    {
        private readonly SqlConnection _db;

        public HomeController(SqlConnection db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            

            await _db.OpenAsync();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
