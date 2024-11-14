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

        public User? GetUser(string email)
        {
            return _userRepository.GetUser(email);
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }
    }
}