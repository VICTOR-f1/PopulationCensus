using Bogus;
using Bogus.DataSets;
using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using PopulationСensus.Infrastructure;


namespace PopulationСensus.Data
{
    public   class EFSeed
    {
        private readonly IUserReader reader;
        private readonly IUserService userService;

        public async void Seed(СensusContext context)
        {
            #region заполнение user
            //for (int i = 0; i < 100; i++)
            //{
            //    Faker faker = new Faker("ru");
            //    var ginternet = new Internet("ru");


            //    var fullName = faker.Person.FullName;
            //    var email = ginternet.Email(fullName, "ru");
            //    var phone = faker.Person.Phone;
            //    var dateofbirth = faker.Person.DateOfBirth;
            //    var state = faker.Address.State();
            //    var city = faker.Address.City();
            //    var street = faker.Address.StreetAddress();
            //    var zipcode = Convert.ToInt32(faker.Address.ZipCode());

            //    Domain.Entities.Address address = new Domain.Entities.Address
            //    {
            //        ZipCode = zipcode,
            //        ApartmentNumber = faker.Random.Short(1, 125),
            //        Street=street,
            //        City=city,
            //        State=state,
            //        User = new List<User>()
            //        {
            //            new User
            //            {
            //                FullName = fullName,
            //                DateOfBirth=dateofbirth,
            //                Email=email,
            //                Password="pSSNnOyW3GTqs45FgPEppkBn/5ccIXyt7BYQUTopb84=",
            //                Salt="14.04.2024 7:16:43638486938033128217",
            //                RoleId=1,
            //                PhoneNumber=phone,
            //            }
            //        }

            //    };
            //  context.Addresses.Add(address);
            #endregion
            List<string> countres = new List<string>() { "Украина","Таджикистан","Азербайджан","Казахстан","Киргизия"};
            for (int i = 20; i < 119; i++)
            {
                Faker faker = new Faker("ru");
                bool gender = faker.Random.Bool();
                byte? NumberChildrenBorn = null;
                short? YearBirthFirstChild = null;
                if (gender == true)
                {
                     NumberChildrenBorn = faker.Random.Byte(0, 5);
                     YearBirthFirstChild = faker.Random.Short(1970, 2024);
                }

                var changeLivedOtherCountries = faker.Random.Byte(0, 100);
                bool LivedOtherCountries=false;
                if (changeLivedOtherCountries > 80)
                     LivedOtherCountries = true;

                string whereLiveBeforeArriving = null;
                if (LivedOtherCountries == true)   
                     whereLiveBeforeArriving = countres[faker.Random.Byte(0,4)];

                var userAnswers = new UserAnswer
                {
                    Gender = gender,
                    NumberChildrenBorn = NumberChildrenBorn,
                    YearBirthFirstChild = YearBirthFirstChild,
                    PlaceBirth = faker.Address.State(),
                    LivedOtherCountries = LivedOtherCountries,
                    WhereLiveBeforeArriving = whereLiveBeforeArriving,
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

                var user = await reader.FindUserAsync(i);
                user.UserAnswersId = userAnswers.Id;
                await userService.UpdateUser(user);
            }
         
        }
    }
}
