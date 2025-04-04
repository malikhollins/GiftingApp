using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;
using ServerApp.Services;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController( UserService userService ) 
        {
            _userService = userService;
        }

        [HttpGet("{userId}/{email}")]
        public async Task<User?> CreateUser(string userId, string email)
        {
            return await _userService.CreateUser(userId, email);
        }

        [HttpGet("{userId}")]
        public async Task<User?> GetUser(string userId)
        {
            return await _userService.GetUser(userId);
        }
    }
}
