using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using PopulationCensus.Infrastructure;
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
        public async Task<IActionResult> ResultCensus(string dateFirst = "", string dateSecond = "", string gender = "", int? CountPeopleLivingHousehold = null, int? numberChildrenBorn = null, string education = "", string state = "", string nativeLanguage = "", string citizenship = "", string nationality = "", string gettingEducation = "", string sourcesOfLiveliHood = "", string whoWereMainJob = "", string typeOfDwelling = "", string heating = "", string waterSupply = "", string hotWaterSupply = "", string waterDisposalSewerage = "", string disposalOfHouseholdWaste = "", int ageStart = 199, int ageEnd = 199)
        {
            List<User> userList = await reader.GetAllUserAsync();
            List<UserAnswer> userListAnswer = await reader.GetAllUserAnswerAsync();
            List<Address> userAdressList = await reader.GetAllАddressAsync();
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
            bool ageCheck = false;


            DateTime dateFistDate = new DateTime();
            DateTime dateSecondDate = new DateTime();
            var dateLast = userListAnswer.OrderByDescending(x => x.Date).Select(x => x.Date).First();
            var yearSelectList = new List<int>();
            foreach (var item in userList)
            {
                yearSelectList.Add(CalculateAge.CalculateAgeYear(item.DateOfBirth, DateTime.Now));
            }
            yearSelectList = yearSelectList.OrderByDescending(x => x).ToList();
            var ageLast = yearSelectList.First();
            var ageFirst = yearSelectList.Last();

            if (dateFirst != "" || dateSecond != "")
            {
                dateCheck = true;
            }
            if (ageEnd != 199 || ageStart != 199)
            {
                ageCheck = true;
            }
            if (dateFirst == "" && dateSecond != "")
            {
                dateFistDate = new DateTime(2024, 03, 22);
                dateFirst = dateFistDate.ToString();
            }
            if (ageStart == 199 && ageEnd!=199)
            {
                ageStart = ageFirst;
            }
            if (dateFirst != "" && dateSecond == "")
            {
                dateSecond = dateLast.ToString();
            }
            if (ageStart != 199 && ageEnd == 199)
            {
                ageEnd = ageLast;
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
                if (dateFistDate > dateLast || dateSecondDate > dateLast)
                {
                    dateCheck = false;
                    ViewBag.modelError = $"Самая последняя билютень была заполненна {dateLast.ToShortDateString()}";

                }
            }
            if (ageCheck)
            {
                if (ageStart>ageEnd)
                {
                    ViewBag.modelError = "Начальная дата не может быть больше конечной";
                    ageCheck = false;
                }
            }


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
            var numberChildrenBornSelectList = userListAnswer
              .Where(x => x.NumberChildrenBorn != null)
              .GroupBy(item => item.NumberChildrenBorn)
              .Select(grp => new { NumberChildrenBorn = grp.Key, Count = grp.Count() })
              .OrderByDescending(item => item.Count)
              .ToList();
           
            var ageStartSelectList = yearSelectList
              .GroupBy(item => item)
              .Select(grp => new { DateOfBirth = grp.Key, Count = grp.Count() })
              .OrderBy(item => item.DateOfBirth)
              .ToList();
            var ageEndSelectList = yearSelectList
              .GroupBy(item => item)
              .Select(grp => new { DateOfBirth = grp.Key, Count = grp.Count() })
              .OrderByDescending(item => item.DateOfBirth)
              .ToList();



            var items2 = nativeLanguageSelectList.Select(answer =>
                new SelectListItem { Text = answer.NativeLanguage.ToString() + ":" + answer.Count.ToString(), Value = answer.NativeLanguage.ToString() });

            var items3 = citizenshipSelectList.Select(answer =>
                new SelectListItem { Text = answer.Citizenship.ToString() + ":" + answer.Count.ToString(), Value = answer.Citizenship.ToString() });

            var items4 = nationalitySelectList.Select(answer =>
                new SelectListItem { Text = answer.Nationality.ToString() + ":" + answer.Count.ToString(), Value = answer.Nationality.ToString() });

            var items5 = stateSelectList.Select(answer =>
                new SelectListItem { Text = answer.State.ToString() + ":" + answer.Count.ToString(), Value = answer.State.ToString() });

            var items6 = numberChildrenBornSelectList.Select(answer =>
                new SelectListItem { Text = "Количество детей: " + answer.NumberChildrenBorn.ToString() + "  сумарное количество: " + answer.Count.ToString(), Value = answer.NumberChildrenBorn.ToString() });

            var items7 = ageStartSelectList.Select(answer =>
                new SelectListItem { Text =  answer.DateOfBirth.ToString(), Value = answer.DateOfBirth.ToString() });

            var items8 = ageEndSelectList.Select(answer =>
                new SelectListItem { Text =  answer.DateOfBirth.ToString(), Value = answer.DateOfBirth.ToString() });

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
                    resident.UserAnswer.Date <= dateSecondDate).ToList();
                    ViewBag.date = $"Начальная дата: {dateFistDate.ToShortDateString()} конечная дата: {dateSecondDate.ToShortDateString()}";
                }
                if (ageCheck)
                {
                    userList = userList.Where(resident =>
                    CalculateAge.CalculateAgeYear(resident.DateOfBirth,DateTime.Now) >= ageStart &&
                    CalculateAge.CalculateAgeYear(resident.DateOfBirth, DateTime.Now) <= ageEnd).ToList();
                    ViewBag.age = $"Начальный возраст: {ageStart} конечный возраст: {ageEnd}";
                }
                userList = userList.Where(resident =>
                    resident.UserAnswerId != null &&
                    resident.UserAnswer.Gender.ToString().Contains(gender) ||
                    gender == "allGender").ToList();

                userList = userList.Where(resident =>
                   resident.UserAnswer.CountPeopleLivingHousehold == CountPeopleLivingHousehold ||
                   CountPeopleLivingHousehold == null).ToList();
                switch (numberChildrenBorn)
                {
                    case < 98:
                        userList = userList.Where(resident =>
                            resident.UserAnswer.NumberChildrenBorn == numberChildrenBorn).ToList();
                        break;
                    case 99:
                        userList = userList.Where(resident =>
                            numberChildrenBorn == 99 && resident.UserAnswer.NumberChildrenBorn == 0).ToList();
                        break;
                    case 100:
                        userList = userList.Where(resident =>
                            numberChildrenBorn == 100 && resident.UserAnswer.NumberChildrenBorn == 2 || resident.UserAnswer.NumberChildrenBorn == 1).ToList();
                        break;
                    case 101:
                        userList = userList.Where(resident =>
                             resident.UserAnswer.NumberChildrenBorn > 3).ToList();
                        break;
                }


                userList = userList.Where(resident =>
                   resident.UserAnswer.Education == education ||
                   education == "allEducation").ToList();

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

                userList = userList.Where(resident =>
                      resident.UserAnswer.GettingEducation == gettingEducation ||
                      gettingEducation == "allGettingEducation").ToList();

                userList = userList.Where(resident =>
                      resident.UserAnswer.SourcesOfLiveliHood == sourcesOfLiveliHood ||
                      sourcesOfLiveliHood == "allSourcesOfLiveliHood").ToList();

                userList = userList.Where(resident =>
                      resident.UserAnswer.WhoWereMainJob == whoWereMainJob ||
                      whoWereMainJob == "allWhoWereMainJob").ToList();

                userList = userList.Where(resident =>
                      resident.UserAnswer.TypeOfDwelling == typeOfDwelling ||
                      typeOfDwelling == "allTypeOfDwelling").ToList();

                userList = userList.Where(resident =>
                     resident.UserAnswer.Heating == heating ||
                     heating == "allHeating").ToList();

                userList = userList.Where(resident =>
                     resident.UserAnswer.WaterSupply == waterSupply ||
                     waterSupply == "allWaterSupply").ToList();

                userList = userList.Where(resident =>
                     resident.UserAnswer.HotWaterSupply == hotWaterSupply ||
                     hotWaterSupply == "allHotWaterSupply").ToList();

                userList = userList.Where(resident =>
                     resident.UserAnswer.WaterDisposalSewerage == waterDisposalSewerage ||
                     waterDisposalSewerage == "allWaterDisposalSewerage").ToList();

                userList = userList.Where(resident =>
                     resident.UserAnswer.DisposalOfHouseholdWaste == disposalOfHouseholdWaste ||
                     disposalOfHouseholdWaste == "allDisposalOfHouseholdWaste").ToList();

                viewModel = new ResidentCatalogViewModel()
                {
                    User = userList
                };


            }
            ViewBag.enumerator = userList.Count;

            viewModel.NativeLanguageSelectList.AddRange(items2);
            viewModel.CitizenshipSelectList.AddRange(items3);
            viewModel.NationalitySelectList.AddRange(items4);
            viewModel.StateSelectList.AddRange(items5);
            viewModel.NumberChildrenBornSelectList.AddRange(items6);
            viewModel.AgeStartSelectList.AddRange(items7);
            viewModel.AgeEndSelectList.AddRange(items8);

            return View(viewModel);
        }


        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ViewingUserAnswer(int userAnswerId)
        {

            var userAnswer = await reader.FindUserAnswerAsync(userAnswerId);
            var user = await reader.FindUserByUserAnswerIdAsync(userAnswerId);
            var Address = await reader.GetAllАddressAsync();
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
            ViewBag.NativeLanguage = userAnswer.NativeLanguage;
            ViewBag.Nationality = userAnswer.Nationality;
            ViewBag.Citizenship = userAnswer.Citizenship;
            ViewBag.Education = userAnswer.Education;
            ViewBag.State = user.Address.State;
            ViewBag.MaritalStatus = userAnswer.MaritalStatus;
            ViewBag.GettingEducation = userAnswer.GettingEducation;
            ViewBag.SourcesOfLiveliHood = userAnswer.SourcesOfLiveliHood;
            ViewBag.WhoWereMainJob = userAnswer.WhoWereMainJob;
            ViewBag.TypeOfDwelling = userAnswer.TypeOfDwelling;
            ViewBag.Heating = userAnswer.Heating;
            ViewBag.WaterSupply = userAnswer.WaterSupply;
            ViewBag.HotWaterSupply = userAnswer.HotWaterSupply;
            ViewBag.WaterDisposalSewerage = userAnswer.WaterDisposalSewerage;
            ViewBag.DisposalOfHouseholdWaste = userAnswer.DisposalOfHouseholdWaste;

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
                    NativeLanguage = userAnswerVm.NativeLanguage,
                    Nationality = userAnswerVm.Nationality,
                    Citizenship = userAnswerVm.Citizenship,
                    Education = userAnswerVm.Education,
                    MaritalStatus = userAnswerVm.MaritalStatus,
                    TypeOfDwelling = userAnswerVm.TypeOfDwelling,
                    GettingEducation = userAnswerVm.GettingEducation,
                    SourcesOfLiveliHood = userAnswerVm.SourcesOfLiveliHood,
                    WhoWereMainJob = userAnswerVm.WhoWereMainJob,
                    Heating = userAnswerVm.Heating,
                    WaterSupply = userAnswerVm.WaterSupply,
                    HotWaterSupply = userAnswerVm.HotWaterSupply,
                    WaterDisposalSewerage = userAnswerVm.WaterDisposalSewerage,
                    DisposalOfHouseholdWaste = userAnswerVm.DisposalOfHouseholdWaste,
                    Date = DateTime.Today

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
