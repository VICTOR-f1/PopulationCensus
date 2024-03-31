using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;

namespace PopulationСensus.Infrastructure
{
    public class CensusReader : ICensusReader
    {
        public Task<List<Resident>> FindResidentAsync(string searchString, int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<Resident?> FindResidentAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Resident>> GetAllResidentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ResidenАddress>> GetResidentAsync()
        {
            throw new NotImplementedException();
        }
    }
}
