using Microsoft.AspNetCore.Mvc;
using synctakerAPI.Core;

namespace synctakerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> _logger;
        private readonly IStatusService _statusService;

        public StatusController(ILogger<StatusController> logger, IStatusService statusService)
        {
            _logger = logger;
            _statusService = statusService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Status>>> GetProjects()
        {
            var statuses = await _statusService.GetAllStatusesAsync();
            return Ok(statuses);
        }
    }
}