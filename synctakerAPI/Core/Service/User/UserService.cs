using System.Linq;
using synctakerAPI.Core;

namespace synctakerAPI.Core
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int?> CreateUserAsync(UserCreateRequest request)
        {
            return await _userRepository.AddUserAsync(request);
        }

        public User? GetUser(string email)
        {
            return _userRepository.GetUser(email);
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            return await _userRepository.DeleteUserAsync(userId);
        }
    }
}