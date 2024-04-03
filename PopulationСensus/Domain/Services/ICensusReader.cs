using PopulationСensus.Domain.Entities;

namespace PopulationСensus.Domain.Services
{
    public interface ICensusReader
    {
        Task<List<Resident>> GetAllResidentAsync();
        Task<List<Resident>> FindResidentAsync(string residentString, string addressString);
        Task<Resident?> FindResidentAsync(int residentId);
        Task<List<Address>> GetAllАddressAsync();
    }
}
