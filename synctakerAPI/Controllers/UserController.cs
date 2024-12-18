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

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid user data.");
            }

            var userId = await _userService.CreateUserAsync(request);
            if (userId != null)
            {
                return Ok(new { UserId = userId });
            }

            return BadRequest("Error creating user.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _userService.DeleteUserAsync(id);

            if (success)
            {
                return NoContent(); // Status 204
            }

            return NotFound(); // Status 404, if not exist
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

        [HttpGet("users")]
        public List<User> GetUsers()
        {
            var users = _userService.GetUsers();
            return users;
        }
    }
}