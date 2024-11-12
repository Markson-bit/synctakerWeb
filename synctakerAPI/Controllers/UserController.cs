using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using synctakerAPI.Core;

namespace synctakerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginRequest request)
        {
            var user = _userService.GetUser(request.Email);
            if (user != null && user.Password == request.Password)
            {
                return Ok(user);
            }

            // status 401 Unauthorized
            return Unauthorized("Invalid username or password");
        }

        //[HttpGet(Name = "GetUser")]
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