using synctakerApi.Core;

namespace synctakerAPI.Core
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllTasksAsync();

        Task<List<TaskModel>> GetTasksByStatus(int userId, TaskService.TaskSpecifiedStatus status);

        Task<TaskModel> GetTaskByIdAsync(int taskId);

        Task<int?> SaveTaskAsync(TaskSaveRequest request);
    }
}