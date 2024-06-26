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
            List<DataPoint> nationality = null;
            List<DataPoint> education = null;
            List<DataPoint> gender = null;
            List<DataPoint> maritalStatus = null;
            List<DataPoint> state = null;
            List<DataPoint> gettingEducation = null;
            List<DataPoint> sourcesOfLiveliHood = null;
            List<DataPoint> whoWereMainJob = null;
            List<DataPoint> typeOfDwelling = null;
            List<DataPoint> heating = null;
            List<DataPoint> waterSupply = null;
            List<DataPoint> hotWaterSupply = null;
            List<DataPoint> waterDisposalSewerage = null;
            List<DataPoint> disposalOfHouseholdWaste = null;


            numberPeoplePassed = objAddDataPoint.NumberPeoplePassed(numberPeoplePassed);
            registeredButNotPass = objAddDataPoint.RegisteredButNotPass(registeredButNotPass);
            nationality = objAddDataPoint.Nationality(nationality);
            education = objAddDataPoint.Education(education);
            gender = objAddDataPoint.Gender(gender);
            maritalStatus = objAddDataPoint.MaritalStatus(maritalStatus);
            state = objAddDataPoint.State(state);
            gettingEducation = objAddDataPoint.GettingEducation(gettingEducation);
            sourcesOfLiveliHood = objAddDataPoint.SourcesOfLiveliHood(sourcesOfLiveliHood);
            whoWereMainJob = objAddDataPoint.WhoWereMainJob(whoWereMainJob);
            typeOfDwelling = objAddDataPoint.TypeOfDwelling(typeOfDwelling);
            heating = objAddDataPoint.Heating(heating);
            waterSupply = objAddDataPoint.WaterSupply(waterSupply);
            hotWaterSupply = objAddDataPoint.HotWaterSupply(hotWaterSupply);
            waterDisposalSewerage = objAddDataPoint.WaterDisposalSewerage(waterDisposalSewerage);
            disposalOfHouseholdWaste = objAddDataPoint.DisposalOfHouseholdWaste(disposalOfHouseholdWaste);


            ViewBag.DataPointsNumberPeoplePassed = JsonConvert.SerializeObject(numberPeoplePassed);
            ViewBag.RegisteredButNotPass = JsonConvert.SerializeObject(registeredButNotPass);
            ViewBag.Nationality = JsonConvert.SerializeObject(nationality);
            ViewBag.Education = JsonConvert.SerializeObject(education);
            ViewBag.Gender = JsonConvert.SerializeObject(gender);
            ViewBag.MaritalStatus = JsonConvert.SerializeObject(maritalStatus);
            ViewBag.State = JsonConvert.SerializeObject(state);
            ViewBag.GettingEducation = JsonConvert.SerializeObject(gettingEducation);
            ViewBag.SourcesOfLiveliHood = JsonConvert.SerializeObject(sourcesOfLiveliHood);
            ViewBag.WhoWereMainJob = JsonConvert.SerializeObject(whoWereMainJob);
            ViewBag.TypeOfDwelling = JsonConvert.SerializeObject(typeOfDwelling);
            ViewBag.Heating = JsonConvert.SerializeObject(heating);
            ViewBag.WaterSupply = JsonConvert.SerializeObject(waterSupply);
            ViewBag.HotWaterSupply = JsonConvert.SerializeObject(hotWaterSupply);
            ViewBag.WaterDisposalSewerage = JsonConvert.SerializeObject(waterDisposalSewerage);
            ViewBag.DisposalOfHouseholdWaste = JsonConvert.SerializeObject(disposalOfHouseholdWaste);

            return View();
        }

        public IActionResult Statistics()
        {


            return View();
        }
    }
}
