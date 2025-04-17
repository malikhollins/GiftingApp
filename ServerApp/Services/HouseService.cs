using Dapper;
using ServerApp.Models;
using System.Data;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class HouseService
    {
        IConnectionService _connectionService;

        public HouseService( IConnectionService connectionService ) 
        {
            _connectionService = connectionService;
        }

        public async Task<IReadOnlyList<House>> GetHousesAsync( int userId )
        {
            using var connection = _connectionService.EstablishConnection();

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("user_id", userId);

            var response = await connection.QueryAsync<House>(
                sql: "[dbo].[GetHouses]",
                param: parameters,
                commandType: CommandType.StoredProcedure);

            return response.ToList();
        }

        public async Task<House> CreateHouseAsync(int userId, string name)
        {
            using var connection = _connectionService.EstablishConnection();

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("user_id", userId);
            parameters.Add("name", name);

            var houseId = await connection.QueryFirstAsync<int>(
                sql: "[dbo].[CreateHouse]",
                param: parameters,
                commandType: CommandType.StoredProcedure);

            return new House { Id = houseId };
        }

        public async Task CreateHouseInvite(int houseId, int inviteId)
        {
            using var connection = _connectionService.EstablishConnection();

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("house_id", houseId);
            parameters.Add("invite_id", inviteId);

            var rowsAffected = await connection.ExecuteAsync(
                sql: "[dbo].[CreateHouseInvite]",
                param: parameters,
                commandType: CommandType.StoredProcedure);

            if (rowsAffected <= 0)
            {
                throw new Exception( "Failed to create house invite" );
            }
        }

        public async Task UpdateHouseInviteStatus(int userId, int houseId, InviteStatus status)
        {
            using var connection = _connectionService.EstablishConnection();

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("user_id", userId);
            parameters.Add("house_id", userId);
            parameters.Add("status", (int)status);

            var rowsAffected = await connection.ExecuteAsync(
                sql: "[dbo].[UpdateHouseInvite]",
                param: parameters,
                commandType: CommandType.StoredProcedure);

            if (rowsAffected <= 0)
            {
                throw new Exception("Failed to update house invite");
            }
        }
    }
}
