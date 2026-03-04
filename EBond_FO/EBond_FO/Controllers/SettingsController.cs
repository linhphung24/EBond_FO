using Microsoft.AspNetCore.Mvc;

namespace EBond_FO.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
