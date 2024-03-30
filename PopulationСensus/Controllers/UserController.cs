using Microsoft.AspNetCore.Mvc;

namespace PopulationСensus.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
    }
}
