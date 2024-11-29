using Microsoft.AspNetCore.Mvc;
using synctakerAPI.Core;

namespace synctakerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITaskService _taskService;

        public TaskController(ILogger<TaskController> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetTasks()
        {
            var tasks = new List<TaskModel>();
            return Ok(tasks);
        }
    }
}