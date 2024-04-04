using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using PopulationСensus.Infrastructure;
using PopulationСensus.ViewModels;

namespace PopulationСensus.Controllers
{
    public class CensusController : Controller
    {
        private readonly ICensusReader reader;
        private readonly IResidentService residentService;
        private readonly IWebHostEnvironment appEnvironment;
        public CensusController(ICensusReader reader, IResidentService residentService, IWebHostEnvironment appEnvironment)
        {
            this.reader = reader;
            this.residentService = residentService;
            this.appEnvironment = appEnvironment;
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

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddCensus()
        {
            var viewModel = new ResidentViewModel();
            var address = await reader.GetAllАddressAsync();
            var items = address.Select(a =>
              new SelectListItem { Text = a.City, Value = a.Id.ToString() });

            viewModel.Address.AddRange(items);
            return View(viewModel);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddCensus(ResidentViewModel residentVm)
        {
            if (!ModelState.IsValid)
            {
                return View(residentVm);
            }
            try
            {
                var resident = new Resident
                {
                    DateOfBirth = residentVm.DateOfBirth,
                    FullName = residentVm.FullName,
                    AddressId = residentVm.AddressId,
                };
                await residentService.AddResident(resident);
            }
            catch
            {
                ModelState.AddModelError("database", "Ошибка при сохранении в базу данных.");
                return View(residentVm);


            }
            return RedirectToAction("ResultCensus", "Census");
        }

    }
}
