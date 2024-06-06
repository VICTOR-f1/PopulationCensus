using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PopulationCensus.Statistics;
using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;

namespace PopulationCensus.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IUserReader reader;
        private readonly IUserService userService;
        public StatisticsController(IUserReader reader, IUserService userService)
        {
            this.reader = reader;
            this.userService = userService;
        }
        public async Task<IActionResult> GraphicsStatistics()
        {
            List<User> user = await reader.GetAllUserAsync();
            List<UserAnswer> userAnswer = await reader.GetAllUserAnswerAsync();
            List<Address> addresses = await reader.GetAllАddressAsync();

            var objAddDataPoint = new AddDataPoint(userAnswer, user, addresses);

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
            List<DataPoint> state = null;

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
            state = objAddDataPoint.State(state);

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
            ViewBag.State = JsonConvert.SerializeObject(state);

            return View();
        }

        public IActionResult Statistics()
        {


            return View();
        }
    }
}
