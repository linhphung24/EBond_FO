using Microsoft.AspNetCore.Mvc;

namespace EBond_FO.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
