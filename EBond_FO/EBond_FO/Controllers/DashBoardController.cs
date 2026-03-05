using EBond_FO.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EBond_FO.Controllers
{
    public class DashBoardController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var list = await BondRepository.GetAll();
            return View(list);
        }
    }
}
