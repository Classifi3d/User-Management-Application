using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        private string PasswordHashing(string inputString)
        {
            var inputBytes = Encoding.UTF8.GetBytes(inputString);
            var inputHash = SHA256.HashData(inputBytes);
            return Convert.ToHexString(inputHash);
        }

        private string GenerateSalt(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            StringBuilder builder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                builder.Append(chars[index]);
            }

            return builder.ToString();
        }

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _dbContext.Users.Include(x => x.Countries).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _dbContext
                .Users
                .Include(u => u.Countries)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return new User();
            }
            else
            {
                return user;
            }
        }

        public async Task<User> AddUserAsync(AddUser addUser)
        {
            var generatedSalt = GenerateSalt(16);
            var user = new User()
            {
                Id = new Guid(),
                Email = addUser.Email,
                Salt = generatedSalt,
                Password = PasswordHashing(addUser.Password + generatedSalt),
                First_Name = addUser.First_Name,
                Last_Name = addUser.Last_Name,
                Type_id = addUser.Type_id,
                Countries = addUser.Countries
            };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UpdateUserAsync(UpdateUser updateUser)
        {
            var generatedSalt = GenerateSalt(16);
            var user = _dbContext
                .Users
                .Where(x => x.Email == updateUser.Email || x.Last_Name == updateUser.Last_Name)
                .FirstOrDefault();
            if (user != null)
            {
                _dbContext.Update(user);
                user.Email = updateUser.Email;
                user.Salt = generatedSalt;
                user.Password = PasswordHashing(updateUser.Password + generatedSalt);
                user.First_Name = updateUser.First_Name;
                user.Last_Name = updateUser.Last_Name;
                user.Type_id = updateUser.Type_id;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<Guid> LoginAsync(LoginUser loginUser)
        {
            var users = await _dbContext.Users.ToListAsync();
            var pass = loginUser.Password;
            foreach (var user in users)
            {
                if (loginUser.Email.Equals(user.Email))
                {
                    if (PasswordHashing(pass + user.Salt).Equals(user.Password))
                    {
                        return user.Id;
                    }
                }
            }
            return Guid.Empty;
        }

        public async Task<User> AddCountryToUserAsync(Guid user_id, Guid country_id)
        {
            var user = await _dbContext.Users.FindAsync(user_id);
            if (user != null)
            {
                var country = await _dbContext.Countries.FindAsync(country_id);
                if (country != null)
                {
                    user.Countries.Append<Countries>(country);
                }
            }

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserCountries> LinkUserCountries(UserCountries userCountries)
        {
            //await _dbContext.Database.ExecuteSqlAsync($"INSERT INTO CountriesUser(UserId, CountryId) VALUES ({userCountries.UserId}, {userCountries.CountryId})");
            var dbUser = _dbContext.Users.Find(userCountries.UserId);
            var newUserCountries = new UserCountries();

            newUserCountries.UserId = userCountries.UserId;

            newUserCountries.CountryId = userCountries.CountryId;

            dbUser.Countries = new List<Countries>();
            var dbCountry = _dbContext.Countries.Find(userCountries.CountryId);
            dbUser.Countries.Add(dbCountry);

            //await _dbContext.UsersCountries.AddAsync(newUserCountries);
            await _dbContext.SaveChangesAsync();
            return userCountries;
        }
    }
}
