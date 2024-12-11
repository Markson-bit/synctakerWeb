using Microsoft.EntityFrameworkCore;
using synctakerApi.Core;

namespace synctakerAPI.Core
{
    public class TaskService : ITaskService
    {
        public enum TaskSpecifiedStatus
        {
            Assigned,
            Realization,
            Review,
            Testing
        }

        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskModel>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllTasksAsync();
        }

        public async Task<List<TaskModel>> GetTasksByStatus(int userId, TaskSpecifiedStatus status)
        {
            return status switch
            {
                TaskSpecifiedStatus.Assigned => await _taskRepository.GetTasksByStatus(userId, TaskSpecifiedStatus.Assigned),
                TaskSpecifiedStatus.Realization => await _taskRepository.GetTasksByStatus(userId, TaskSpecifiedStatus.Realization),
                TaskSpecifiedStatus.Review => await _taskRepository.GetTasksByStatus(userId, TaskSpecifiedStatus.Review),
                TaskSpecifiedStatus.Testing => await _taskRepository.GetTasksByStatus(userId, TaskSpecifiedStatus.Testing),
                _ => throw new ArgumentException("Invalid task status.")
            };
        }

        public async Task<TaskModel> GetTaskByIdAsync(int taskId)
        {
            return await _taskRepository.GetTaskByIdAsync(taskId);
        }

        public async Task<int?> SaveTaskAsync(TaskSaveRequest request)
        {
            return await _taskRepository.SaveTaskAsync(request);
        }
    }
}