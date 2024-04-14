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

        public IActionResult Index() 
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ResultCensus(int userAnswersId)
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
        public IActionResult GratitudeCensusSuccess()
        {

            return View();
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

            var user = await reader.FindUserByEmailAsync(User.Identity.Name);
            if (user.UserAnswersId==null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("GratitudeCensusSuccess", "Census");

            }

        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCensus(UserAnswerViewModel userAnswerVm)
        {
            if (!ModelState.IsValid)
            {
                return View(userAnswerVm);
            }
            try
            {           
                var userAnswers = new UserAnswer
                {
                    Gender= userAnswerVm.Gender,
                    NumberChildrenBorn= userAnswerVm.NumberChildrenBorn,
                    YearBirthFirstChild= userAnswerVm.YearBirthFirstChild,
                    PlaceBirth = userAnswerVm.PlaceBirth,
                    LivedOtherCountries= userAnswerVm.LivedOtherCountries,
                    WhereLiveBeforeArriving= userAnswerVm.WhereLiveBeforeArriving,
                    YearArrival= userAnswerVm.YearArrival,
                    SpeakRussian = userAnswerVm.SpeakRussian,
                    UseRussianInConversation = userAnswerVm.UseRussianInConversation,
                    NativeLanguage = userAnswerVm.NativeLanguage,
                    Citizenship = userAnswerVm.Citizenship,
                    Education = userAnswerVm.Education,
                    HaveDegree= userAnswerVm.HaveDegree,
                    CanReadAndWrite= userAnswerVm.CanReadAndWrite,
                    MaritalStatus= userAnswerVm.MaritalStatus,
                    Nationality= userAnswerVm.Nationality,

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
                return View(userAnswerVm);
            }
            return RedirectToAction("CensusSuccess", "Census");
           
        }

    }
}
