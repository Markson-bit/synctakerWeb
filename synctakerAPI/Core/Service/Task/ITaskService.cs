using synctakerApi.Core;

namespace synctakerAPI.Core
{
    public interface ITaskService
    {
        Task<List<TaskModel>> GetAllTasksAsync();

        Task<TaskModel> GetTaskByIdAsync(int taskId);

        Task<List<TaskModel>> GetTasksByStatus(int userId, TaskService.TaskSpecifiedStatus status);

        Task<int?> SaveTaskAsync(TaskSaveRequest request);
    }
}