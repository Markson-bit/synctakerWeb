using Microsoft.EntityFrameworkCore;

namespace synctakerAPI.Core
{
    public class StatusRepository : IStatusRepository
    {
        private readonly AppDbContext _context;

        public StatusRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Status>> GetAllStatusesAsync()
        {
            return await _context.Status.ToListAsync();
        }
    }
}