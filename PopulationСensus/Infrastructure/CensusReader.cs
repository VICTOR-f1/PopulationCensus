using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using System.Reflection.PortableExecutable;
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
        public async Task<List<Resident>> FindResidentAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return await residents.GetAllAsync();
            }
            else
            {
                var a = await GetAllАddressAsync();
                /*переделать если останеться время*/
                int residentAddress = 0;
                try
                {
                    residentAddress = a.Find(resAddress =>
                    resAddress.State.Contains(searchString) ||
                    resAddress.City.Contains(searchString) ||
                    resAddress.Street.Contains(searchString) ||
                    resAddress.ApartmentNumber.ToString().Contains(searchString) ||
                    resAddress.Street.Contains(searchString)).Id;
                }
                catch (Exception ex)
                {
                    
                }
                

                return await residents.FindWhere(resident =>
                resident.AddressId == residentAddress ||
                resident.FullName.Contains(searchString) ||
                resident.DateOfBirth.ToString().Contains(searchString));
            }
        }


        public async Task<Resident?> FindResidentAsync(int residentId) => await residents.FindAsync(residentId);

        public async Task<List<Resident>> GetAllResidentAsync() => await residents.GetAllAsync();

        public async Task<List<Address>> GetAllАddressAsync() => await addresses.GetAllAsync();


    }
}
