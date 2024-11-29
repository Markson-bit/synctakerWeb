namespace synctakerAPI.Core
{
    public interface ITaskService
    {
        Task<List<TaskModel>> GetAllTasksAsync();
    }
}