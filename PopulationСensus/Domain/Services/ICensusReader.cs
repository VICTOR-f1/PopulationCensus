using PopulationСensus.Domain.Entities;

namespace PopulationСensus.Domain.Services
{
    public interface IUserReader
    {
        Task<List<User>> GetAllUserAsync();
        Task<List<User>> FindUserAsync(string residentString);
        Task<User?> FindUserAsync(int residentId);
        Task<List<Address>> GetAllАddressAsync();
    }
}
