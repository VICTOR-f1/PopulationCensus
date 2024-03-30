using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PopulationСensus.Controllers
{
    public class CensusController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
