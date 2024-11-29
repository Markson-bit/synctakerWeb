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

        public async Task<List<TaskModel>> GetAllTasksAsync()
        {
            return await _context.TaskModel
                .Include(t => t.Project)
                .Include(t => t.AssignedTo)
                .Include(t => t.Reviewer)
                .Include(t => t.Tester)
                .Include(t => t.Status)
                .ToListAsync();
        }
    }
}