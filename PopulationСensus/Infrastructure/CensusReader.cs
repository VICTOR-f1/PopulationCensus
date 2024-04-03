using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using static System.Reflection.Metadata.BlobBuilder;

namespace PopulationСensus.Infrastructure
{
    public class CensusReader : ICensusReader
    {
        private readonly IRepository<Resident> residents;
        private readonly IRepository<Address> addresses;

        public CensusReader(IRepository<Resident> residents, IRepository<Address> addresses)
        {
            this.residents = residents;
            this.addresses = addresses;
        }
        public async Task<List<Resident>> FindResidentAsync(string searchString, string addressString)
        {
            if (string.IsNullOrEmpty(searchString) && string.IsNullOrEmpty(addressString))
            {
                return await residents.GetAllAsync();
            }
            else if (!string.IsNullOrEmpty(searchString) && string.IsNullOrEmpty(addressString))
            {
                return await residents.FindWhere(resident => resident.FullName.Contains(searchString) || resident.DateOfBirth.ToString().Contains(searchString));
            }
            else
            {
                int residentAddress = addresses.FindWhere(resAddress=>resAddress.City.Contains(addressString)).Id;
                return await residents.FindWhere(resident => resident.AddressId == residentAddress || (resident.FullName.Contains(searchString) || resident.Address.ToString().Contains(searchString)));
            }
        }


        public async Task<Resident?> FindResidentAsync(int residentId) =>  await residents.FindAsync(residentId);

        public async Task<List<Resident>> GetAllResidentAsync() => await residents.GetAllAsync();

        public async Task<List<Address>> GetAllАddressAsync()=> await addresses.GetAllAsync();
        
        
    }
}
