using Microsoft.AspNetCore.Mvc;

namespace EBond_API.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
