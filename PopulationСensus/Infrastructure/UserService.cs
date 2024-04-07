using PopulationСensus.Data;
using PopulationСensus.Domain.Entities;
using PopulationСensus.Domain.Services;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace PopulationСensus.Infrastructure
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> users;
        private readonly IRepository<Role> roles;
        private readonly IRepository<Address> addresses;
        public UserService(IRepository<User> usersRepository,
            IRepository<Role> rolesRepository,
            IRepository<Address> addresses)
        {
            users = usersRepository;
            roles = rolesRepository;
            this.addresses = addresses;

        }
        private string GetSalt() =>
        DateTime.UtcNow.ToString() + DateTime.Now.Ticks;
        private string GetSha256(string password, string salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password + salt);
            byte[] hashBytes = SHA256.HashData(passwordBytes);
            return Convert.ToBase64String(hashBytes);
        }
        public async Task<User?> GetUserAsync(string username, string password)
        {
           

            User? user = (await users.FindWhere(u => u.Email == username)).FirstOrDefault();
       
            if (user is null)
            {
                return null;
            }
            string hashPassword = GetSha256(password, user.Salt);
            if (user.Password != hashPassword)
            {
                return null;
            }
            return user;
        }

        public async Task<bool> IsUserExistsAsync(string username)
        {
            username = username.Trim();
            User? found = (await users.FindWhere(u => u.Email == username)).FirstOrDefault();
            //возвращает логическое значение `true`,
            //если переменная `found` не равна `null`,
            //и `false`, если переменная `found` равна `null`
            return found is not null;
        }

        public async Task<User> RegistrationAsync(string fullname, string username, string password)
        {
            // проверяем, есть ли пользователь с таким же username
            bool userExists = await IsUserExistsAsync(username);
            if (userExists) throw new ArgumentException("Username already exists");

            // находим роль "клиент"
            Role? clientRole = (await roles.FindWhere(r => r.Name == "client")).FirstOrDefault();

            if (clientRole is null)
                throw new InvalidOperationException("Role 'client' not found in database");

            // добавляем пользователя
            User toAdd = new User
            {
                FullName = fullname,
                Email = username,
                Salt = GetSalt(),
                RoleId = clientRole.Id
            };
            toAdd.Password = GetSha256(password, toAdd.Salt);

            return await users.AddAsync(toAdd);
        }
        public async Task AddResident(User resident)
        {
            await users.AddAsync(resident);
        }
        public async Task UpdateResident(User resident)
        {
            await users.UpdateAsync(resident);
        }
        public async Task DeleteResident(User resident)
        {
            await users.DeleteAsync(resident);
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
