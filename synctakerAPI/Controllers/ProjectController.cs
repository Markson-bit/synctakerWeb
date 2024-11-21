using Microsoft.AspNetCore.Mvc;
using synctakerAPI.Core;

namespace synctakerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectService _projectService;

        public ProjectController(ILogger<ProjectController> logger, IProjectService projectService)
        {
            _logger = logger;
            _projectService = projectService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProject([FromBody] ProjectCreateRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid project data.");
            }

            var projectId = await _projectService.CreateProjectAsync(request);
            if (projectId != null)
            {
                return Ok(new { ProjectId = projectId });
            }

            return BadRequest("Error creating project.");
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var success = await _projectService.DeleteProjectAsync(id);

            if (success)
            {
                return NoContent(); // Status 204
            }

            return NotFound(); // Status 404, if not exist
        }

        [HttpPut("update/{projectId}")]
        public async Task<IActionResult> UpdateProject(int projectId, [FromBody] ProjectCreateRequest request)
        {
            var success = await _projectService.UpdateProjectAsync(projectId, request);

            if (success)
            {
                return Ok();
            }

            return BadRequest("Failed to update project.");
        }
    }
}