using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> AddUserAsync(AddUser user);
        Task<bool> UpdateUserAsync(UpdateUser user);
        Task<bool> DeleteUserAsync(Guid id);
        Task<Guid> LoginAsync(LoginUser loginUser);
        Task<UserCountries> LinkUserCountries(UserCountries userCountries);
    }
}
