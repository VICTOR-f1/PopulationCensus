using PopulationСensus.Domain.Entities;

namespace PopulationСensus.Domain.Services
{
    public interface IUserReader
    {
        Task<List<User>> GetAllUserAsync();
        Task<List<UserAnswer>> GetAllUserAnswerAsync();
        Task<List<User>> FindUserAsync(string userString);
        Task<User?> FindUserAsync(int userId);
        Task<UserAnswer?> FindUserAnswerAsync(int userAnswerId);
        Task<User?> FindUserByEmailAsync(string mail);
        Task<List<Address>> GetAllАddressAsync();
        Task<List<User>> GetUserAsync(string gender="");

    }
}
