using Microsoft.AspNetCore.Mvc;
using synctakerApi.Core;
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
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("status/{userId}")]
        public async Task<ActionResult<List<TaskModel>>> GetSpecifiedTasks(int userId, [FromQuery] TaskService.TaskSpecifiedStatus status)
        {
            var tasks = await _taskService.GetTasksByStatus(userId, status);
            return Ok(tasks);
        }

        [HttpGet("task/{taskId}")]
        public async Task<IActionResult> GetTaskById(int taskId)
        {
            var task = await _taskService.GetTaskByIdAsync(taskId);

            if (task == null)
            {
                return NotFound($"Task with ID {taskId} not found.");
            }

            return Ok(task);
        }

        [HttpPost("save")]
        public async Task<IActionResult> SaveTask([FromBody] TaskSaveRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid project data.");
            }

            var taskId = await _taskService.SaveTaskAsync(request);
            if (taskId != null)
            {
                return Ok(new { TaskId = taskId });
            }

            return BadRequest("Error creating project.");
        }
    }
}