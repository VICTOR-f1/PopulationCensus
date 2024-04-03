using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> ResultCensus(string searchString = "", string addressString = "")
        {
            var viewModel = new ResidentCatalogViewModel()
            {
                Resident = await reader.FindResidentAsync(searchString, addressString),
                Address = await reader.GetAllАddressAsync(),
            };
          
            
            return View(viewModel);
        }

    }
}
