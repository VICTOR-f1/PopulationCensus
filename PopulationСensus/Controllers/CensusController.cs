using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PopulationCensus.Statistics;
using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using PopulationСensus.ViewModels;
using System.Diagnostics;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

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
        public async Task<IActionResult> ResultCensus(string gender = "",string canReadAndWrite="", string haveDegree = "", int? YearBirthFirstChild=null, int? numberChildrenBorn=null,string placeBirth="", string livedOtherCountries = "",string whereLiveBeforeArriving="")
        {
            List<UserAnswer> userListAnswer = await reader.GetAllUserAnswerAsync();

            ResidentCatalogViewModel viewModel = null;

         

            if (gender == "")
            {


                viewModel = new ResidentCatalogViewModel()
                {
                    User = await reader.GetAllUserAsync(),
                    Address = await reader.GetAllАddressAsync(),
                    UserAnswers = userListAnswer

                };

            }
            else
            {
                List<User> userList = await reader.GetAllUserAsync();
                List<User> userListCopy = await reader.GetAllUserAsync();
                viewModel = new ResidentCatalogViewModel()
                {
                    Address = await reader.GetAllАddressAsync(),
                    UserAnswers = userListAnswer,
                };

                foreach (var item in userList)
                {
                    if (item.UserAnswerId != null)
                    {
                        userListCopy.Add(item);
                    }
                }
                userList = userListCopy;

                userList = userList.Where(resident =>
               resident.UserAnswerId != null &&
               resident.UserAnswer.Gender.ToString().Contains(gender) ||
                gender == "allGender").ToList();

               // userList = userList.Where(resident =>
               // resident.UserAnswer.HaveDegree.ToString().Contains(haveDegree) ||
               // haveDegree == "allHaveDegree").ToList();

               // userList = userList.Where(resident =>
               //resident.UserAnswer.CanReadAndWrite.ToString().Contains(canReadAndWrite) ||
               //canReadAndWrite == "AllCanReadAndWrite").ToList();

               // userList = userList.Where(resident =>
               //resident.UserAnswer.YearBirthFirstChild==YearBirthFirstChild ||
               //YearBirthFirstChild == null).ToList();

               // userList = userList.Where(resident =>
               //  resident.UserAnswer.NumberChildrenBorn ==numberChildrenBorn ||
               // numberChildrenBorn == null).ToList();

               // userList = userList.Where(resident =>
               //resident.UserAnswer.PlaceBirth == placeBirth ||
               //placeBirth == "allPlaceBirth").ToList();

                //userList = userList.Where(resident =>
                //resident.UserAnswer.LivedOtherCountries.ToString().Contains(livedOtherCountries) ||
                //livedOtherCountries == null).ToList();

                //userList = userList.Where(resident =>
                //resident.UserAnswer.WhereLiveBeforeArriving == whereLiveBeforeArriving ||
                //whereLiveBeforeArriving == "whereLiveBeforeArriving").ToList();

                viewModel = new ResidentCatalogViewModel()
                {
                    User = userList
                };
            }
            ViewBag.enumerator = viewModel.User.Count;

            var userAnswersSelectList = userListAnswer
             .GroupBy(item => item.PlaceBirth)
             .Select(grp => new { PlaceBirth = grp.Key, Count = grp.Count() })
             .OrderByDescending(item => item.Count)
             .ToList();
            var whereLiveBeforeArrivingSelectList = userListAnswer
               .Where(x => x.WhereLiveBeforeArriving != null)
               .GroupBy(item => item.WhereLiveBeforeArriving)
               .Select(grp => new { WhereLiveBeforeArriving = grp.Key, Count = grp.Count() })
               .OrderByDescending(item => item.Count)
               .ToList();
            var items = userAnswersSelectList.Select(answer =>
           new SelectListItem { Text = answer.PlaceBirth.ToString() + ":" + answer.Count.ToString(), Value = answer.PlaceBirth.ToString() });

            var items2 = whereLiveBeforeArrivingSelectList.Select(answer =>
          new SelectListItem { Text = answer.WhereLiveBeforeArriving.ToString() + ":" + answer.Count.ToString(), Value = answer.WhereLiveBeforeArriving.ToString() });

            viewModel.UserAnswersSelectList.AddRange(items);
            viewModel.WhereLiveBeforeArrivingSelectList.AddRange(items2);

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
            if (user.UserAnswerId == null)
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
                user.UserAnswerId = userAnswers.Id;
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
