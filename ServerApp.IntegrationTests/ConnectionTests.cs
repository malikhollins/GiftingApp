using Microsoft.Extensions.Configuration;
using WebAPI.Services;

namespace ServerApp.IntegrationTests
{
    public class ConnectionTests
    {
        public static IConnectionService SetUpConnection()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", optional: false);
            IConfiguration config = builder.Build();
            return new DapperConnectionService(config);
        }

        [Fact]
        public void Test_Connection()
        {
            var connectionService = SetUpConnection();
            Assert.NotNull(connectionService);
            var dbConnection = connectionService.EstablishConnection();
            Assert.NotNull(dbConnection);
            dbConnection.Close();
        }
    }
}