using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using System.Diagnostics;

namespace PopulationСensus.Infrastructure
{
    public class UserReader : IUserReader
    {
        private readonly IRepository<User> users;
        private readonly IRepository<Address> addresses;
        private readonly IRepository<UserAnswer> usersAnswers;


        public UserReader(IRepository<User> users, IRepository<Address> addresses, IRepository<UserAnswer> usersAnswers)
        {
            this.users = users;
            this.addresses = addresses;
            this.usersAnswers = usersAnswers;
        }
        public async Task<List<User>> FindUserAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return await users.GetAllAsync();
            }
            else
            {
                searchString = searchString.Trim();

                return await users.FindWhere(resident =>
                resident.FullName.Contains(searchString) ||
                resident.Address.State.Contains(searchString) ||
                resident.Address.City.Contains(searchString) ||
                resident.Address.ZipCode.ToString().Contains(searchString) ||
                resident.Address.Street.Contains(searchString) ||
                resident.Address.ApartmentNumber.ToString().Contains(searchString) ||
                resident.Address.Street.Contains(searchString) ||
                resident.DateOfBirth.ToString().Contains(searchString));
            }
        }
        public async Task<User> FindUserByEmailAsync(string mail) => await users.FirstOrDefult(resident => resident.Email == mail);

        public async Task<User> FindUserAsync(int userId) => await users.FindAsync(userId);

        public async Task<List<User>> GetAllUserAsync() => await users.GetAllAsync();
        public async Task<List<UserAnswer>> GetAllUserAnswerAsync() => await usersAnswers.GetAllAsync();

        public async Task<List<Address>> GetAllАddressAsync() => await addresses.GetAllAsync();

        public async Task<UserAnswer> FindUserAnswerAsync(int userAnswerId) => await usersAnswers.FindAsync(userAnswerId);


    }
}
