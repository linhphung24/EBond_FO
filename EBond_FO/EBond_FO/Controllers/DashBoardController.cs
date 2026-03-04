using Microsoft.AspNetCore.Mvc;

namespace EBond_FO.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
