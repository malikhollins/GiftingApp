using Microsoft.AspNetCore.Mvc;
using ServerApp.Models;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly HouseService _houseService;

        public HouseController(HouseService houseService )
        {
            _houseService = houseService;
        }

        [HttpGet("get/{userId}")]
        public async Task<IEnumerable<House>> GetHouses( int userId )
        {
            return await _houseService.GetHousesAsync( userId );
        }

        [HttpGet("create/{userId}/{name}")]
        public async Task<House> CreateHouse(int userId, string name)
        {
            return await _houseService.CreateHouseAsync(userId, name);
        }

        [HttpGet("create/invite/{houseId}/{userIdToInvite}")]
        public async Task CreateHouseInvite(int houseId, int userIdToInvite)
        {
            await _houseService.CreateHouseInvite(houseId, userIdToInvite);
        }


        [HttpGet("set/invite/{userId}/{houseId}/{status}")]
        public async Task UpdateHouseInviteStatus(int userId, int houseId, InviteStatus status)
        {
            await _houseService.UpdateHouseInviteStatus(userId, houseId, status);
        }
    }
}
