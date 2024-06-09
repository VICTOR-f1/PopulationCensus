using Bogus;
using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;


namespace PopulationСensus.Data
{
    public class EFSeed
    {
        private readonly IUserReader reader;
        private readonly IUserService userService;
        public EFSeed(IUserReader reader, IUserService userService)
        {
            this.reader = reader;
            this.userService = userService;
        }
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
            List<string> countres = new List<string>() { "Украина", "Таджикистан", "Азербайджан", "Казахстан", "Киргизия" };
            List<string> language = new List<string>() { "Украинский", "Русский", "Таджикский", "Казахстанский", "Киргизкий", "Русский", "Русский", };
            List<string> nationalityList = new List<string>() { "Украинец", "Русский", "Таджик", "Казах", "Киргиз", "Русский", "Русский", };
            List<string> education = new List<string>() { "Общее", "Средне профессиональное", "Высшеее" };
            List<string> maritalStatusList = new List<string>() { "В зарегистрированном браке", "В незарегистрированном супружеском союзе", "Офицально разведён(а)", "Разошёлся(лась)", "Вдовец вдова", "Никогда не состоял(а) в браке, супружеском союзе" };

            for (int i = 19; i < 121; i++)
            {
                var user = await reader.FindUserAsync(i);

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
                bool LivedOtherCountries = false;
                if (changeLivedOtherCountries > 80)
                    LivedOtherCountries = true;

                string whereLiveBeforeArriving = null;
                if (LivedOtherCountries == true)
                    whereLiveBeforeArriving = countres[faker.Random.Byte(0, 4)];

                short? yearArrival = null;
                if (LivedOtherCountries == true)
                {
                    short dateOfBirth = 0;
                    yearArrival = faker.Random.Short(dateOfBirth, (short)(dateOfBirth + 10));

                }

                bool speakRussian = true;
                if (LivedOtherCountries)
                    speakRussian = faker.Random.Bool();

                bool useRussianInConversation = true;
                if (speakRussian)
                    useRussianInConversation = faker.Random.Bool();

                bool haveDegree = faker.Random.Bool();
                bool canReadAndWrite = false;
                if (!haveDegree)
                {
                    canReadAndWrite = faker.Random.Bool();
                }
                var userAnswers = new UserAnswer
                {
                    //Gender = gender,
                    //NumberChildrenBorn = NumberChildrenBorn,
                    //CountPeopleLivingHousehold = YearBirthFirstChild,
                    //PlaceBirth = faker.Address.State(),
                    //LivedOtherCountries = LivedOtherCountries,
                    //WhereLiveBeforeArriving = whereLiveBeforeArriving,
                    //YearArrival = yearArrival,
                    //SpeakRussian = speakRussian,
                    //UseRussianInConversation = useRussianInConversation,
                    //NativeLanguage = language[faker.Random.Byte(0, 6)],
                    //Citizenship = countres[faker.Random.Byte(0, 4)],
                    //Education = education[faker.Random.Byte(0, 2)],
                    //HaveDegree = haveDegree,
                    //CanReadAndWrite = canReadAndWrite,
                    //MaritalStatus = maritalStatusList[faker.Random.Byte(0, 5)],
                    //Nationality = nationalityList[faker.Random.Byte(0, 6)],

                };
                await userService.AddUserAnswer(userAnswers);

                user.UserAnswerId = userAnswers.Id;
                await userService.UpdateUser(user);
            }
            var a = "";

        }
    }

}

