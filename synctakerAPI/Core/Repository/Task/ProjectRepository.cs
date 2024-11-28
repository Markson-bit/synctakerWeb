using Microsoft.EntityFrameworkCore;

namespace synctakerAPI.Core
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}