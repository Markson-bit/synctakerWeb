using Microsoft.AspNetCore.Mvc;
using synctakerAPI.Core;

namespace synctakerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(ILogger<ProjectController> logger)
        {
            _logger = logger;
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