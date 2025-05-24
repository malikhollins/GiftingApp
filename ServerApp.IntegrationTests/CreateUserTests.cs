using ServerApp.Services;

namespace ServerApp.IntegrationTests
{
    public class CreateUserTests
    {
        private const string TestEmail = "test-email@gmail.com";

        [Fact]
        public async Task Create_User()
        {
            var connectionService = ConnectionTests.SetUpConnection();
            var userService = new UserService(connectionService);
            var user = await userService.CreateUser(authId: "0011", TestEmail);
            Assert.NotNull(user);
            Assert.True(user.Email == TestEmail);
        }
    }
}
