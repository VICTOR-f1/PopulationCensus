using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PopulationCensus.Statistics;
using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using PopulationСensus.ViewModels;

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
                User = await reader.FindUserAsync(searchString),
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
            ViewBag.UseRussianInConversation = userAnswer.UseRussianInConversation;
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

        public async Task<IActionResult> Statistics()
        {
            List<User> user = await reader.GetAllUserAsync();
            List<UserAnswer> userAnswer = await reader.GetAllUserAnswerAsync();
            var objAddDataPoint = new AddDataPoint(userAnswer, user);

            List<DataPoint> numberPeoplePassed = null;
            List<DataPoint> registeredButNotPass = null;
            List<DataPoint> canWriteAndRead = null;
            List<DataPoint> haveDegree = null;
            List<DataPoint> nationality = null;
            List<DataPoint> livedOtherCountries = null;
            List<DataPoint> whereLiveBeforeArriving = null;
            List<DataPoint> education = null;
            List<DataPoint> gender = null;
            List<DataPoint> maritalStatus = null;

            numberPeoplePassed = objAddDataPoint.NumberPeoplePassed(numberPeoplePassed);
            registeredButNotPass = objAddDataPoint.RegisteredButNotPass(registeredButNotPass);
            canWriteAndRead = objAddDataPoint.CanWriteAndRead(canWriteAndRead);
            haveDegree = objAddDataPoint.HaveDegree(haveDegree);
            nationality = objAddDataPoint.Nationality(nationality);
            livedOtherCountries = objAddDataPoint.LivedOtherCountries(livedOtherCountries);
            whereLiveBeforeArriving = objAddDataPoint.WhereLiveBeforeArriving(whereLiveBeforeArriving);
            education = objAddDataPoint.Education(education);
            gender = objAddDataPoint.Gender(gender);
            maritalStatus = objAddDataPoint.MaritalStatus(maritalStatus);

            ViewBag.DataPointsNumberPeoplePassed = JsonConvert.SerializeObject(numberPeoplePassed);
            ViewBag.RegisteredButNotPass = JsonConvert.SerializeObject(registeredButNotPass);
            ViewBag.CanWriteAndRead = JsonConvert.SerializeObject(canWriteAndRead);
            ViewBag.HaveDegree = JsonConvert.SerializeObject(haveDegree);
            ViewBag.Nationality = JsonConvert.SerializeObject(nationality);
            ViewBag.LivedOtherCountries = JsonConvert.SerializeObject(livedOtherCountries);
            ViewBag.WhereLiveBeforeArriving = JsonConvert.SerializeObject(whereLiveBeforeArriving);
            ViewBag.Education = JsonConvert.SerializeObject(education);
            ViewBag.Gender = JsonConvert.SerializeObject(gender);
            ViewBag.MaritalStatus = JsonConvert.SerializeObject(maritalStatus);

            return View();
        }

        [Authorize]
        public IActionResult CensusSuccess()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddCensus()
        {
            var user = await reader.FindUserByEmailAsync(User.Identity.Name);
            if (user.UserAnswersId == null)
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
                    Gender = userAnswerVm.Gender,
                    NumberChildrenBorn = userAnswerVm.NumberChildrenBorn,
                    YearBirthFirstChild = userAnswerVm.YearBirthFirstChild,
                    PlaceBirth = userAnswerVm.PlaceBirth,
                    LivedOtherCountries = userAnswerVm.LivedOtherCountries,
                    WhereLiveBeforeArriving = userAnswerVm.WhereLiveBeforeArriving,
                    YearArrival = userAnswerVm.YearArrival,
                    SpeakRussian = userAnswerVm.SpeakRussian,
                    UseRussianInConversation = userAnswerVm.UseRussianInConversation,
                    NativeLanguage = userAnswerVm.NativeLanguage,
                    Citizenship = userAnswerVm.Citizenship,
                    Education = userAnswerVm.Education,
                    HaveDegree = userAnswerVm.HaveDegree,
                    CanReadAndWrite = userAnswerVm.CanReadAndWrite,
                    MaritalStatus = userAnswerVm.MaritalStatus,
                    Nationality = userAnswerVm.Nationality,

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
