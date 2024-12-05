using synctakerApi.Core;

namespace synctakerAPI.Core
{
    public interface ITaskService
    {
        Task<List<TaskModel>> GetAllTasksAsync();

        Task<TaskModel> GetTaskByIdAsync(int taskId);

        Task<int?> SaveTaskAsync(TaskSaveRequest request);
    }
}