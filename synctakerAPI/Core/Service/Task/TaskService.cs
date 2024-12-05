using Microsoft.EntityFrameworkCore;
using synctakerApi.Core;

namespace synctakerAPI.Core
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<TaskModel>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllTasksAsync();
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