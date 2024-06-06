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
        private readonly IRepository<UserAnswer> userAnswers;
        public UserService(IRepository<User> usersRepository,
            IRepository<Role> rolesRepository,
            IRepository<Address> addresses, IRepository<UserAnswer> userAnswers)
        {
            users = usersRepository;
            roles = rolesRepository;
            this.addresses = addresses;
            this.userAnswers = userAnswers;

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
            return found is not null;
        }

        public async Task<User> RegistrationAsync(string fullname, string username, string password, DateTime dateOfBirth, string phoneNumber, string state, string street, short apartmentNumber, int zipCode)
        {
            // проверяем, есть ли пользователь с таким же username
            bool userExists = await IsUserExistsAsync(username);
            if (userExists) throw new ArgumentException("Email already exists");

            Address address = new Address
            {
                State = state,
                Street = street,
                ApartmentNumber = apartmentNumber,
                ZipCode = zipCode
            };
            await AddAddress(address);
            int adressId = address.Id;
            //иногда отпадает id
            User addUser = new User
            {

                FullName = fullname,
                Email = username,
                Salt = GetSalt(),
                RoleId = 1,
                DateOfBirth = dateOfBirth,
                PhoneNumber = phoneNumber,
                AddressId = adressId,

            };
            Debug.WriteLine("Send to debug output.");
            Debug.WriteLine("Send to debug output.");
            Debug.WriteLine("Send to debug output.");
            Debug.WriteLine("Send to debug output.");

            Debug.WriteLine(addUser.Id);
            addUser.Password = GetSha256(password, addUser.Salt);
            return await users.AddAsync(addUser);
        }
        public async Task AddUser(User resident)
        {
            await users.AddAsync(resident);
        }
        public async Task UpdateUser(User resident)
        {
            await users.UpdateAsync(resident);
        }
        public async Task DeleteUser(User resident)
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

        public async Task AddUserAnswer(UserAnswer userAnswer)
        {
            await userAnswers.AddAsync(userAnswer);
        }
        public async Task UpdateUserAnswer(UserAnswer userAnswer)
        {
            await userAnswers.UpdateAsync(userAnswer);
        }
    }
}
