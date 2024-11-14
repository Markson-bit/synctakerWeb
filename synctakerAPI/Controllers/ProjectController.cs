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

        //[HttpGet(Name = "GetProject")]
        //public User Get()
        //{
        //    return new User
        //    {
        //        Id = 1,
        //        FirstName = "Kacper",
        //        LastName = "Górski",
        //        Email = "kac.per@kacper.de",
        //        AdminRights = true
        //    };
        //}
    }
}