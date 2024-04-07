﻿using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using System.Reflection.PortableExecutable;
using static System.Reflection.Metadata.BlobBuilder;

namespace PopulationСensus.Infrastructure
{
    public class CensusReader : IUserReader
    {
        private readonly IRepository<User> users;
        private readonly IRepository<Address> addresses;

        public CensusReader(IRepository<User> users, IRepository<Address> addresses)
        {
            this.users = users;
            this.addresses = addresses;
        }
        public async Task<List<User>> FindUserAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return await users.GetAllAsync();
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
                

                return await users.FindWhere(resident =>
                //resident.AddressId == residentAddress ||
                resident.FullName.Contains(searchString) ||
                resident.DateOfBirth.ToString().Contains(searchString));
            }
        }


        public async Task<User> FindUserAsync(int residentId) => await users.FindAsync(residentId);

        public async Task<List<User>> GetAllUserAsync() => await users.GetAllAsync();

        public async Task<List<Address>> GetAllАddressAsync() => await addresses.GetAllAsync();


    }
}
