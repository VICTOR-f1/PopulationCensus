using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PopulationСensus.Data;
using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using PopulationСensus.Infrastructure;
using PopulationСensus.ViewModels;
using System.Diagnostics;
using System.Reflection;
using System.Security.Claims;

namespace PopulationСensus.Controllers
{
    public class CensusController : Controller
    {
        private readonly IUserReader reader;
        private readonly IUserService userService;

        public CensusController(IUserReader reader, IUserService userService)
        {
            this.reader = reader;
            this.userService = userService;
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
       
        [Authorize]
        public  IActionResult CensusSuccess()
        {

            return View();
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddCensus()
        {
            
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCensus(UserAnswerViewModel residentVm)
        {
            if (!ModelState.IsValid)
            {
                return View(residentVm);
            }
            try
            {           
                var userAnswers = new UserAnswer
                {
                    Gender=residentVm.Gender,
                    NumberChildrenBorn= residentVm.NumberChildrenBorn,
                    YearBirthFirstChild=residentVm.YearBirthFirstChild,
                    PlaceBirth = residentVm.PlaceBirth

                };
                await userService.AddUserAnswer(userAnswers);

                var user = await reader.FindUserByEmailAsync(User.Identity.Name);
                user.UserAnswersId = userAnswers.Id;
                await userService.UpdateUser(user);
            }
            catch
            {
                ViewBag.modelError = "Ошибка при сохранении в базу данных.";
                ModelState.AddModelError("database", "Ошибка при сохранении в базу данных.");
                return View(residentVm);
            }
            return RedirectToAction("Index", "Census");
           
        }

    }
}
