using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User> AddUserAsync(AddUser user)
        {
            return await _userRepository.AddUserAsync(user);
        }

        public async Task<bool> UpdateUserAsync(UpdateUser updateUser)
        {
            return await _userRepository.UpdateUserAsync(updateUser);
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        public async Task<Guid> LoginAsync(LoginUser loginUser)
        {
            return await _userRepository.LoginAsync(loginUser);
        }

        public async Task<UserCountries> LinkUserCountries(UserCountries userCountries)
        {
            return await _userRepository.LinkUserCountries(userCountries);
        }
    }
}
