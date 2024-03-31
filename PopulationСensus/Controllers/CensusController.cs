using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PopulationСensus.Domain.Services;

namespace PopulationСensus.Controllers
{
    public class CensusController : Controller
    {
        private readonly ICensusReader reader;

        public CensusController(ICensusReader reader)
        {
            this.reader = reader;
        }

        [Authorize]
        public IActionResult Index() 
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ResultCensus()
        {
            return View(await reader.GetAllResidentAsync());
        }

    }
}
