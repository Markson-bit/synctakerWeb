using System.Linq;
using synctakerAPI.Core;

namespace synctakerAPI.Core
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User? GetUser(string email)
        {
            return _context.User.FirstOrDefault(u => u.Email == email);
        }
    }
}