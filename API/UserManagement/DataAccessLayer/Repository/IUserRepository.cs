using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> AddUserAsync(AddUser addUser);
        Task<bool> UpdateUserAsync(UpdateUser updateUser);
        Task<bool> DeleteUserAsync(Guid id);
        Task<Guid> LoginAsync(LoginUser loginUser);
        Task<User> AddCountryToUserAsync(Guid user_id, Guid country_id);
        Task<UserCountries> LinkUserCountries(UserCountries userCountries);
    }
}
