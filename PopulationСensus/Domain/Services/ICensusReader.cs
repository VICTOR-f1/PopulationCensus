using PopulationСensus.Domain.Entities;

namespace PopulationСensus.Domain.Services
{
    public interface ICensusReader
    {
        Task<List<Resident>> GetAllResidentAsync();
        Task<List<Resident>> FindResidentAsync(string searchString, int categoryId);
        Task<Resident?> FindResidentAsync(int bookId);
        Task<List<ResidenАddress>> GetResidentAsync();
    }
}
