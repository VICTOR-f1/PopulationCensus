using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;

namespace PopulationСensus.Infrastructure
{
    public class UserService : IUserService
    {
        public Task<User?> GetUserAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserExistsAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> RegistrationAsync(string fullname, string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
