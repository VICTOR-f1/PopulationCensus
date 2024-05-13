﻿using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;

namespace PopulationСensus.Infrastructure
{
    public class UserReader : IUserReader
    {
        private readonly IRepository<User> users;
        private readonly IRepository<Address> addresses;
        private readonly IRepository<UserAnswer> usersAnswers;  


        public UserReader(IRepository<User> users, IRepository<Address> addresses, IRepository<UserAnswer> usersAnswers)
        {
            this.users = users;
            this.addresses = addresses;
            this.usersAnswers = usersAnswers;
        }
        public async Task<List<User>> FindUserAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return await users.GetAllAsync();
            }
            else
            {
                searchString=searchString.Trim();
                //var a = await GetAllАddressAsync();
                ///*переделать если останеться время*/
                //int residentAddress = 0;
                //try
                //{
                //    residentAddress = a.Find(resAddress =>
                //    resAddress.State.Contains(searchString) ||
                //    resAddress.City.Contains(searchString) ||
                //    resAddress.Street.Contains(searchString) ||
                //    resAddress.ApartmentNumber.ToString().Contains(searchString) ||
                //    resAddress.Street.Contains(searchString)).Id;
                //}
                //catch 
                //{
                    
                //}
                
                return await users.FindWhere(resident =>
                //resident.AddressId == residentAddress ||
                resident.FullName.Contains(searchString) ||
                resident.DateOfBirth.ToString().Contains(searchString));
            }
        }
        public async Task<User> FindUserByEmailAsync(string mail) => await users.FirstOrDefult(resident =>resident.Email==mail);
  
        public async Task<User> FindUserAsync(int userId) => await users.FindAsync(userId);

        public async Task<List<User>> GetAllUserAsync() => await users.GetAllAsync();
		public async Task<List<UserAnswer>> GetAllUserAnswerAsync() => await usersAnswers.GetAllAsync();

		public async Task<List<Address>> GetAllАddressAsync() => await addresses.GetAllAsync();

        public async Task<UserAnswer> FindUserAnswerAsync(int userAnswerId) => await usersAnswers.FindAsync(userAnswerId);


    }
}
