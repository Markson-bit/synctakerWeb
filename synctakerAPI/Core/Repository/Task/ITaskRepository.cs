using synctakerApi.Core;

namespace synctakerAPI.Core
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllTasksAsync();

        Task<TaskModel> GetTaskByIdAsync(int taskId);

        Task<int?> SaveTaskAsync(TaskSaveRequest request);
    }
}