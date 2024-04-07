using PopulationСensus.Domain.Entities;

namespace PopulationСensus.Domain.Services
{
    public interface IResidentService
    {
        Task AddResident(Resident resident);
        Task UpdateResident(Resident resident);
        Task DeleteResident(Resident resident);
        Task AddAddress(Address address);
        Task UpdateAddress(Address address);
        Task DeleteAddress(Address address);
    }
}
