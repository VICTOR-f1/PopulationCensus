using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;

namespace PopulationСensus.Infrastructure
{
    public class ResidentService:IResidentService
    {
        private readonly IRepository<Resident> residents;
        private readonly IRepository<Address> addresses;


        public ResidentService(IRepository<Resident> residents, IRepository<Address> addresses)
        {
            this.residents = residents;
            this.addresses = addresses;
        }

        public async Task AddResident(Resident resident)
        {
            await residents.AddAsync(resident);
        }
        public async Task UpdateResident(Resident resident)
        {
            await residents.UpdateAsync(resident);
        }
        public async Task DeleteResident(Resident resident)
        {
            await residents.DeleteAsync(resident);
        }

        public async Task AddAddress(Address address)
        {
            await addresses.AddAsync(address);
        }

        public async Task UpdateAddress(Address address)
        {
            await addresses.UpdateAsync(address);
        }

        public async Task DeleteAddress(Address address)
        {
            await addresses.DeleteAsync(address);
        }
    }
}
