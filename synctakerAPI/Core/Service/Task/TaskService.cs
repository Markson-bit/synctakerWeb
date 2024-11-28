namespace synctakerAPI.Core
{
    public class TaskService : ITaskService
    {
        private readonly ITaskService _taskRepository;

        public TaskService(ITaskService taskRepository)
        {
            _taskRepository = taskRepository;
        }
    }
}