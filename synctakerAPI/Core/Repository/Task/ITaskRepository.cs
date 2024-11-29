namespace synctakerAPI.Core
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllTasksAsync();
    }
}