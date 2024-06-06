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
        public async Task<IActionResult> ResultCensus(string dateFirst = "", string dateSecond = "", string gender = "", string canReadAndWrite = "", string haveDegree = "", int? CountPeopleLivingHousehold = null, int? numberChildrenBorn = null, string placeBirth = "", string livedOtherCountries = "", string whereLiveBeforeArriving = "", string speakRussian = "", string state = "", string nativeLanguage = "", string citizenship = "", string nationality = "")
        {
            List<User> userList = await reader.GetAllUserAsync();
            List<UserAnswer> userListAnswer = await reader.GetAllUserAnswerAsync();
            List<Address> userAdressList= await reader.GetAllАddressAsync();
            List<User> userListWithAllHaveUserAnswer = new List<User>();
            foreach (var item in userList)
            {
                if (item.UserAnswerId != null)
                {
                    userListWithAllHaveUserAnswer.Add(item);
                }
            }
            userList = userListWithAllHaveUserAnswer;
            ResidentCatalogViewModel viewModel = null;
            bool dateCheck = false;

            DateTime dateFistDate = new DateTime();
            DateTime dateSecondDate = new DateTime();
            var dateLast= userListAnswer.OrderByDescending(x => x.Date).Select(x => x.Date).First();
            if (dateFirst != "" || dateSecond != "")
            {
                dateCheck = true;
            }
            if (dateFirst == "" && dateSecond != "")
            {
                dateFistDate = new DateTime(2024, 03, 22);
                dateFirst = dateFistDate.ToString();
            }
            if (dateFirst != "" && dateSecond == "")
            {
                dateSecond = dateLast.ToString();
            }

            if (dateCheck)
            {

                dateFistDate = DateTime.Parse(dateFirst);
                dateSecondDate = DateTime.Parse(dateSecond);

                if (dateFistDate > dateSecondDate)
                {
                    dateCheck = false;
                    ViewBag.modelError = "Начальная дата не может быть больше конечной";
                }
                if (dateFistDate < new DateTime(2024, 03, 22) || dateSecondDate < new DateTime(2024, 03, 22))
                {
                    dateCheck = false;
                    ViewBag.modelError = "Самая первая билютень была заполненна 2024-03-22";

                }
                if (dateFistDate > dateLast || dateSecondDate >dateLast)
                {
                    dateCheck = false;
                    ViewBag.modelError = $"Самая последняя билютень была заполненна {dateLast.ToShortDateString()}";

                }
            }

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
            var nativeLanguageSelectList = userListAnswer
              .Where(x => x.NativeLanguage != null)
              .GroupBy(item => item.NativeLanguage)
              .Select(grp => new { NativeLanguage = grp.Key, Count = grp.Count() })
              .OrderByDescending(item => item.Count)
              .ToList();
            var citizenshipSelectList = userListAnswer
              .Where(x => x.Citizenship != null)
              .GroupBy(item => item.Citizenship)
              .Select(grp => new { Citizenship = grp.Key, Count = grp.Count() })
              .OrderByDescending(item => item.Count)
              .ToList();
            var nationalitySelectList = userListAnswer
              .Where(x => x.Nationality != null)
              .GroupBy(item => item.Nationality)
              .Select(grp => new { Nationality = grp.Key, Count = grp.Count() })
              .OrderByDescending(item => item.Count)
              .ToList();
            var stateSelectList = userAdressList
              .Where(x => x.State != null)
              .GroupBy(item => item.State)
              .Select(grp => new { State = grp.Key, Count = grp.Count() })
              .OrderByDescending(item => item.Count)
              .ToList();
            var items = userAnswersSelectList.Select(answer =>
                new SelectListItem { Text = answer.PlaceBirth.ToString() + ":" + answer.Count.ToString(), Value = answer.PlaceBirth.ToString() });

            var items2 = whereLiveBeforeArrivingSelectList.Select(answer =>
                new SelectListItem { Text = answer.WhereLiveBeforeArriving.ToString() + ":" + answer.Count.ToString(), Value = answer.WhereLiveBeforeArriving.ToString() });

            var items3 = nativeLanguageSelectList.Select(answer =>
                new SelectListItem { Text = answer.NativeLanguage.ToString() + ":" + answer.Count.ToString(), Value = answer.NativeLanguage.ToString() });

            var items4 = citizenshipSelectList.Select(answer =>
                new SelectListItem { Text = answer.Citizenship.ToString() + ":" + answer.Count.ToString(), Value = answer.Citizenship.ToString() });

            var items5 = nationalitySelectList.Select(answer =>
                new SelectListItem { Text = answer.Nationality.ToString() + ":" + answer.Count.ToString(), Value = answer.Nationality.ToString() });

            var items6 = stateSelectList.Select(answer =>
                new SelectListItem { Text = answer.State.ToString() + ":" + answer.Count.ToString(), Value = answer.State.ToString() });
           
            if (gender == "")
            {
                viewModel = new ResidentCatalogViewModel()
                {
                    User = userList,
                    Address = await reader.GetAllАddressAsync(),
                    UserAnswers = userListAnswer

                };

            }
            else
            {
                viewModel = new ResidentCatalogViewModel()
                {
                    Address = await reader.GetAllАddressAsync(),
                    UserAnswers = userListAnswer,
                };
                if (dateCheck)
                {
                    userList = userList.Where(resident =>
                    resident.UserAnswer.Date >= dateFistDate &&
                    resident.UserAnswer.Date <=dateSecondDate).ToList();
                    ViewBag.date = $"Начальная дата: {dateFistDate.ToShortDateString()} конечная дата: {dateSecondDate.ToShortDateString()}";
                }
                userList = userList.Where(resident =>
                    resident.UserAnswerId != null &&
                    resident.UserAnswer.Gender.ToString().Contains(gender) ||
                    gender == "allGender").ToList();

                userList = userList.Where(resident =>
                    resident.UserAnswer.HaveDegree.ToString().Contains(haveDegree) ||
                    haveDegree == "allHaveDegree").ToList();

                userList = userList.Where(resident =>
                   resident.UserAnswer.CanReadAndWrite.ToString().Contains(canReadAndWrite) ||
                   canReadAndWrite == "AllCanReadAndWrite").ToList();

                userList = userList.Where(resident =>
                   resident.UserAnswer.CountPeopleLivingHousehold == CountPeopleLivingHousehold ||
                   CountPeopleLivingHousehold == null).ToList();

                userList = userList.Where(resident =>
                   resident.UserAnswer.NumberChildrenBorn == numberChildrenBorn ||
                   numberChildrenBorn == null).ToList();

                userList = userList.Where(resident =>
                   resident.UserAnswer.PlaceBirth == placeBirth ||
                   placeBirth == "allPlaceBirth").ToList();

                userList = userList.Where(resident =>
                    resident.UserAnswer.LivedOtherCountries.ToString().Contains(livedOtherCountries) ||
                    livedOtherCountries == "allLivedOtherCountries").ToList();

                userList = userList.Where(resident =>
                    resident.UserAnswer.WhereLiveBeforeArriving == whereLiveBeforeArriving ||
                    whereLiveBeforeArriving == "allWhereLiveBeforeArriving").ToList();

                userList = userList.Where(resident =>
                    resident.UserAnswer.SpeakRussian.ToString().Contains(speakRussian) ||
                    speakRussian == "allSpeakRussian").ToList();

                userList = userList.Where(resident =>
                    resident.Address.State == state ||
                    state == "allState").ToList();

                userList = userList.Where(resident =>
                  resident.UserAnswer.NativeLanguage == nativeLanguage ||
                  nativeLanguage == "allNativeLanguage").ToList();

                userList = userList.Where(resident =>
                    resident.UserAnswer.Citizenship == citizenship ||
                    citizenship == "allCitizenship").ToList();

                userList = userList.Where(resident =>
                      resident.UserAnswer.Nationality == nationality ||
                      nationality == "allNationality").ToList();
                viewModel = new ResidentCatalogViewModel()
                {
                    User = userList
                };

                
            }
            ViewBag.enumerator = userList.Count;

            viewModel.UserAnswersSelectList.AddRange(items);
            viewModel.WhereLiveBeforeArrivingSelectList.AddRange(items2);
            viewModel.NativeLanguage.AddRange(items3);
            viewModel.Citizenship.AddRange(items4);
            viewModel.Nationality.AddRange(items5);
            viewModel.State.AddRange(items6);

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
            if (userAnswer.Gender)
                ViewBag.Gender = "Женщина";
            else
                ViewBag.Gender = "Мужчина";

            ViewBag.CountPeopleLivingHousehold = userAnswer.CountPeopleLivingHousehold;
            ViewBag.NumberChildrenBorn = userAnswer.NumberChildrenBorn;
            ViewBag.WhereLiveBeforeArriving = userAnswer.WhereLiveBeforeArriving ?? "пусто";
            if (userAnswer.LivedOtherCountries)
                ViewBag.LivedOtherCountries = "Да";
            else
                ViewBag.LivedOtherCountries = "Нет";
            ViewBag.YearArrival = userAnswer.YearArrival;
            if (userAnswer.SpeakRussian)
                ViewBag.SpeakRussian = "Да";
            else
                ViewBag.SpeakRussian = "Нет";
            if (userAnswer.UseRussianInConversation)
                ViewBag.UseRussianInConversation = "Да";
            else
                ViewBag.UseRussianInConversation = "Нет";
            ViewBag.NativeLanguage = userAnswer.NativeLanguage;
            ViewBag.Nationality = userAnswer.Nationality;
            ViewBag.Citizenship = userAnswer.Citizenship;
            ViewBag.Education = userAnswer.Education;
            if (userAnswer.HaveDegree)
                ViewBag.HaveDegree = "Да";
            else
                ViewBag.HaveDegree = "Нет";
            if (userAnswer.CanReadAndWrite)
                ViewBag.CanReadAndWrite = "Да";
            else
                ViewBag.CanReadAndWrite = "Нет";
            ViewBag.MaritalStatus = userAnswer.MaritalStatus;

            if (userAnswer.CountPeopleLivingHousehold == null)
                ViewBag.CountPeopleLivingHousehold = "пусто";
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
                    CountPeopleLivingHousehold = userAnswerVm.CountPeopleLivingHousehold,
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
