using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PopulationСensus.Data;
using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using PopulationСensus.Infrastructure;
using PopulationСensus.ViewModels;

namespace PopulationСensus.Controllers
{
    public class CensusController : Controller
    {
        private readonly IUserReader reader;
        public CensusController(IUserReader reader)
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
                 User= await reader.FindUserAsync(searchString),
                Address = await reader.GetAllАddressAsync(),
            };
            
           
            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddCensus()
        {
            
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCensus(ResidentViewModel residentVm)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(residentVm);
            //}
            //try
            //{
            //    var userAnswers = new UserAnswers
            //    {
            //        ZipCode = residentVm.ZipCode,
            //        ApartmentNumber = residentVm.ApartmentNumber,
            //        Street = residentVm.Street,
            //        City = residentVm.City,
            //        State = residentVm.State

            //    };
            //    await residentService.AddAddress(address);

            //    int adressId = address.Id;

            //    var resident = new Resident()
            //    {
            //        DateOfBirth = residentVm.DateOfBirth,
            //        FullName = residentVm.FullName,
            //        AddressId = adressId
            //    };
            //    await residentService.AddResident(resident);
            //}
            //catch
            //{
            //    ModelState.AddModelError("database", "Ошибка при сохранении в базу данных.");
            //    return View(residentVm);


            //}
            //return RedirectToAction("ResultCensus", "Census");
            return View();
        }

    }
}
