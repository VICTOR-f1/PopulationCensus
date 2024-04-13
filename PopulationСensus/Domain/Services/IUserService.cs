using PopulationСensus.Domain.Entities;

namespace PopulationСensus.Domain.Services
{
    public interface IUserService
    {
        Task<bool> IsUserExistsAsync(string username);
        Task<User> RegistrationAsync(string fullname, string username, string password, DateTime dateOfBirth, string phoneNumber, string state, string city, string street, short apartmentNumber, int zipCode);
        Task<User?> GetUserAsync(string username, string password);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
        Task AddAddress(Address address);
        Task UpdateAddress(Address address);
        Task DeleteAddress(Address address);
        Task AddUserAnswer(UserAnswer userAnswer);

    }
}
