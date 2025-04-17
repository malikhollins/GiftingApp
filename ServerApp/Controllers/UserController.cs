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

        [HttpGet("create/{authId}/{email}")]
        public async Task<User?> CreateUser(string authId, string email)
        {
            return await _userService.CreateUser(authId, email);
        }

        [HttpGet("get/{authId}")]
        public async Task<User?> GetUser(string authId)
        {
            return await _userService.GetUser(authId);
        }

        [HttpGet("get/bulk/{searchTerm}/{usingName}")]
        public async Task<IReadOnlyList<User?>> BulkGetUser(string searchTerm, bool usingName )
        {
            return usingName
                ? await _userService.BulkGetUser(string.Empty, searchTerm)
                : await _userService.BulkGetUser(searchTerm, string.Empty);
        }

        [HttpGet("get/invites/{userId}")]
        public async Task<IReadOnlyList<Invite>> GetInvites(int userId)
        {
            return await _userService.GetUserInvites(userId);
        }
    }
}
