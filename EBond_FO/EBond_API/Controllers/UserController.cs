using Microsoft.AspNetCore.Mvc;

namespace EBond_API.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
