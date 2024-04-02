using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using static System.Reflection.Metadata.BlobBuilder;

namespace PopulationСensus.Infrastructure
{
    public class CensusReader : ICensusReader
    {
        private readonly IRepository<Resident> residents;
        private readonly IRepository<Address> addresses;

        public CensusReader(IRepository<Resident> residents, IRepository<Address> residentsAddresses)
        {
            this.residents = residents;
            this.addresses = residentsAddresses;
        }
        public async Task<List<Resident>> FindResidentAsync(string searchString, int addressId) => (searchString, addressId) switch
        {
            ("" or null, 0) => await residents.GetAllAsync(),
            (_, 0) => await residents.FindWhere(resident => resident.FullName.Contains(searchString) || resident.Address.ToString().Contains(searchString)),
            (_,_)=> await residents.FindWhere(resident=>resident.AddressId== addressId&&(resident.FullName.Contains(searchString) 
            || resident.Address.ToString().Contains(searchString))),
          
        };

        public async Task<Resident?> FindResidentAsync(int bookId) =>  await residents.FindAsync(bookId);

        public async Task<List<Resident>> GetAllResidentAsync() => await residents.GetAllAsync();

        public async Task<List<Address>> GetAllАddressAsync()=> await addresses.GetAllAsync();
        
        
    }
}
