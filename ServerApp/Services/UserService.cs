using Dapper;
using ServerApp.Models;
using System.Data;
using WebAPI.Services;

namespace ServerApp.Services
{
    public class UserService
    {
        IConnectionService _connectionService;

        public UserService(IConnectionService connectionService) 
        {
            this._connectionService = connectionService;
        }

        public async Task<User?> CreateUser( string authId, string email )
        {
            using var connection = _connectionService.EstablishConnection();

            DynamicParameters parameters = new();
            parameters.Add("user_id", authId);
            parameters.Add("email", email);

           var identity = await connection.QueryFirstAsync<int>(
                sql: "[dbo].[CreateUser]",
                param: parameters,
                commandType: CommandType.StoredProcedure);

            return new User
            {
                Id = identity,
                Email = email,
            };
        }

        public async Task<User?> GetUser(string authId)
        {
            using var connection = _connectionService.EstablishConnection();

            DynamicParameters parameters = new();
            parameters.Add("user_id", authId);

            var user = await connection.QueryFirstAsync<User>(
                 sql: "[dbo].[GetUser]",
                 param: parameters,
                 commandType: CommandType.StoredProcedure);

            return user is null
                ? throw new Exception( "Error finding user" )
                : new User
            {
                Name = user.Name,
                Email = user.Email,
            };
        }

        public async Task<IReadOnlyList<User?>> BulkGetUser(string email, string name)
        {
            using var connection = _connectionService.EstablishConnection();

            DynamicParameters parameters = new();
            parameters.Add("email", email);
            parameters.Add("name", name);

            var users = await connection.QueryAsync<User>(
                 sql: "[dbo].[BulkGetUsers]",
                 param: parameters,
                 commandType: CommandType.StoredProcedure);

            return [.. users];
        }

        public async Task<IReadOnlyList<Invite>> GetUserInvites(int userId)
        {
            using var connection = _connectionService.EstablishConnection();

            DynamicParameters parameters = new();
            parameters.Add("user_id", userId);

            var invites = await connection.QueryAsync<Invite>(
                 sql: "[dbo].[GetUserinvites]",
                 param: parameters,
                 commandType: CommandType.StoredProcedure);

            return [.. invites];
        }
    }
}
