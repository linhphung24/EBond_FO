using Microsoft.AspNetCore.Mvc;

namespace EBond_FO.Controllers
{
    public class AnalyticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
