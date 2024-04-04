using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using static System.Reflection.Metadata.BlobBuilder;

namespace PopulationСensus.Infrastructure
{
    public class ResidentService:IResidentService
    {
        private readonly IRepository<Resident> residents;

        public ResidentService(IRepository<Resident> residents)
        {
            this.residents = residents;
        }

        public async Task AddResident(Resident book)
        {
            await residents.AddAsync(book);
        }
        public async Task UpdateResident(Resident book)
        {
            await residents.UpdateAsync(book);
        }
        public async Task DeleteResident(Resident book)
        {
            await residents.DeleteAsync(book);
        }
    }
}
