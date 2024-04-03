using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using PopulationСensus.ViewModels;

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
        public async Task<IActionResult> ResultCensus(string searchString = "")
        {
            var viewModel = new ResidentCatalogViewModel()
            {
                Resident = await reader.FindResidentAsync(searchString),
                Address = await reader.GetAllАddressAsync(),
            };
            var a = await reader.GetAllАddressAsync();

            int residentAddress = a.Find(resAddress => resAddress.City.Contains(searchString)).Id;
            ViewBag.text2=residentAddress;

            return View(viewModel);
        }

    }
}
