using Azure.Core;
using Microsoft.EntityFrameworkCore;
using synctakerApi.Core;
using System.Threading.Tasks;

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

        public async Task<TaskModel> GetTaskByIdAsync(int taskId)
        {
            var task = await _context.TaskModel.FirstOrDefaultAsync(t => t.Id == taskId);

            if (task == null)
            {
                throw new Exception($"Task with ID {taskId} not found.");
            }
            return task;
        }

        public async Task<int?> SaveTaskAsync(TaskSaveRequest request)
        {
            TaskModel task;

            if (request.TaskId == 0 || request.TaskId == null)
            {
                task = new TaskModel
                {
                    Priority = request.Priority,
                    StatusId = request.StatusId,
                    ProjectId = request.ProjectId,
                    AssignedToId = request.AssignedToId,
                    ReviewerId = request.ReviewerId,
                    TestId = request.TesterId,
                    RealizationPlanned = request.RealizationPlanned,
                    Description = request.Description,
                };

                _context.TaskModel.Add(task);
            }
            else
            {
                task = await _context.TaskModel.FindAsync(request.TaskId);

                if (task == null)
                {
                    throw new Exception($"Task with ID {request.TaskId} not found.");
                }

                task.Priority = request.Priority;
                task.StatusId = request.StatusId;
                task.ProjectId = request.ProjectId;
                task.AssignedToId = request.AssignedToId;
                task.ReviewerId = request.ReviewerId;
                task.TestId = request.TesterId;
                task.RealizationPlanned = request.RealizationPlanned;
                task.Description = request.Description;

                _context.TaskModel.Update(task);
            }

            await _context.SaveChangesAsync();

            // Zwracamy ID zadania
            return task.Id;
        }
    }
}