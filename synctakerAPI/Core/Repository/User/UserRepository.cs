using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public List<User> GetUsers()
        {
            return _context.User.Include(p => p.ProjectUsers).ThenInclude(p => p.Project).ToList();
        }
    }
}