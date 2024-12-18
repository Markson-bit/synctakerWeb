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

        public async Task<int?> AddUserAsync(UserCreateRequest request)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                AdminRights = request.AdminRights
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }

        public User? GetUser(string email)
        {
            return _context.User.FirstOrDefault(u => u.Email == email);
        }

        public List<User> GetUsers()
        {
            return _context.User.Include(p => p.ProjectUsers).ThenInclude(p => p.Project).ToList();
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _context.User.FindAsync(userId);

            if (user == null)
            {
                return false; // not exist
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}