﻿using PopulationСensus.Domain.Entities;

namespace PopulationСensus.Domain.Services
{
    public interface IUserService
    {
        Task<bool> IsUserExistsAsync(string username);
        Task<User> RegistrationAsync(string fullname, string username, string password, DateTime dateOfBirth, string phoneNumber, string state, string city, string street, short apartmentNumber, int zipCode);
        Task<User?> GetUserAsync(string username, string password);
        Task AddResident(User resident);
        Task UpdateResident(User resident);
        Task DeleteResident(User resident);
        Task AddAddress(Address address);
        Task UpdateAddress(Address address);
        Task DeleteAddress(Address address);
    }
}
