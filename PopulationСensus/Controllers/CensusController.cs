using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using PopulationСensus.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using PopulationCensus.Domain.Entities;

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
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ViewingUserAnswer(int userAnswerId)
        {

            var userAnswer = await reader.FindUserAnswerAsync(userAnswerId);
            if (userAnswer is null)
            {
                return NotFound();
            }

            ViewBag.PlaceBirth = userAnswer.PlaceBirth;
            ViewBag.Gender = userAnswer.Gender;
            ViewBag.YearBirthFirstChild = userAnswer.YearBirthFirstChild;
            ViewBag.NumberChildrenBorn = userAnswer.NumberChildrenBorn;
            ViewBag.WhereLiveBeforeArriving = userAnswer.WhereLiveBeforeArriving ?? "пусто";
            ViewBag.LivedOtherCountries = userAnswer.LivedOtherCountries;           
            ViewBag.YearArrival = userAnswer.YearArrival;
            ViewBag.SpeakRussian = userAnswer.SpeakRussian;
            ViewBag.UseRussianInConversation=userAnswer.UseRussianInConversation;
            ViewBag.NativeLanguage = userAnswer.NativeLanguage;
            ViewBag.Nationality = userAnswer.Nationality;
            ViewBag.Citizenship = userAnswer.Citizenship;
            ViewBag.Education = userAnswer.Education;
            ViewBag.HaveDegree = userAnswer.HaveDegree;
            ViewBag.CanReadAndWrite = userAnswer.CanReadAndWrite;
            ViewBag.MaritalStatus = userAnswer.MaritalStatus;

            if (userAnswer.YearBirthFirstChild == null)
                ViewBag.YearBirthFirstChild = "пусто";
            if (userAnswer.NumberChildrenBorn == null)
                ViewBag.NumberChildrenBorn = "пусто";
            if (userAnswer.YearArrival == null)
                ViewBag.YearArrival = "пусто";

            return View();
        }
      
        [Authorize]
        public IActionResult GratitudeCensusSuccess()
        {

            return View();
        }

        public IActionResult Statistics()
        {
			List<DataPoint> dataPoints = new List<DataPoint>();

			dataPoints.Add(new DataPoint(1496255400000, 2500));
			dataPoints.Add(new DataPoint(1496341800000, 2790));
			dataPoints.Add(new DataPoint(1496428200000, 3380));
			dataPoints.Add(new DataPoint(1496514600000, 4940));
			dataPoints.Add(new DataPoint(1496601000000, 4020));
			dataPoints.Add(new DataPoint(1496687400000, 3390));
			dataPoints.Add(new DataPoint(1496773800000, 4200));
			dataPoints.Add(new DataPoint(1496860200000, 3150));
			dataPoints.Add(new DataPoint(1496946600000, 3230));
			dataPoints.Add(new DataPoint(1497033000000, 4200));
			dataPoints.Add(new DataPoint(1497119400000, 5210));
			dataPoints.Add(new DataPoint(1497205800000, 4940));
			dataPoints.Add(new DataPoint(1497292200000, 3500));
			dataPoints.Add(new DataPoint(1497378600000, 3790));
			dataPoints.Add(new DataPoint(1497465000000, 3230));
			dataPoints.Add(new DataPoint(1497551400000, 2900));
			dataPoints.Add(new DataPoint(1497637800000, 3080));
			dataPoints.Add(new DataPoint(1497724200000, 3370));
			dataPoints.Add(new DataPoint(1497810600000, 2880));
			dataPoints.Add(new DataPoint(1497897000000, 3170));
			dataPoints.Add(new DataPoint(1497983400000, 3280));
			dataPoints.Add(new DataPoint(1498069800000, 4070));
			dataPoints.Add(new DataPoint(1498156200000, 5280));
			dataPoints.Add(new DataPoint(1498242600000, 4970));
			dataPoints.Add(new DataPoint(1498329000000, 2560));
			dataPoints.Add(new DataPoint(1498415400000, 2790));
			dataPoints.Add(new DataPoint(1498501800000, 3800));
			dataPoints.Add(new DataPoint(1498588200000, 4400));
			dataPoints.Add(new DataPoint(1498674600000, 4020));
			dataPoints.Add(new DataPoint(1498761000000, 3900));

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

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
