using Auth0.OidcClient;
using ClientApp.Models;
using ClientApp.Utils;
using IdentityModel.OidcClient;
using System.Diagnostics;

namespace ClientApp.Services
{
    public class LoginService
    {
        private readonly Auth0Client _authClient;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserInfoService _userInfoService;

        public LoginService(Auth0Client client, IHttpClientFactory httpClientFactory, UserInfoService userInfoService)
        {
            _authClient = client;
            _httpClientFactory = httpClientFactory;
            _userInfoService = userInfoService;
        }

        /// <summary>
        /// Build the uri for logging in
        /// </summary>
        /// <param name="authId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        private static string BuildUri(string? authId, string? email) => string.Format("/api/User/get/{0}/{1}", authId, email);

        /// <summary>
        /// Verify with the database that the user exists
        /// </summary>
        /// <remarks>
        /// TODO: Move this to the callback for auth0
        /// </remarks>
        /// <param name="auth0LoginResult"></param>
        /// <returns></returns>
        private async Task<User?> VerifyAuth0LoginAsync(LoginResult auth0LoginResult)
        {
            // gather inputs for uri parameters
            var authId = auth0LoginResult.User.Claims.FirstOrDefault(claim => claim.Type == "sub");
            var email = auth0LoginResult.User.Claims.FirstOrDefault(claim => claim.Type == "name");
            var uri = BuildUri(authId?.Value, email?.Value);

            // verify the auth0 response
            HttpClient httpClient = _httpClientFactory.CreateClient("base-url");
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            return await response.DeserializeAsync<User>();
        }

        public async Task<bool> LoginAsync()
        {
            try
            {
                var loginResult = await _authClient.LoginAsync();
                if (loginResult.IsError)
                {
                    // auth0 doesn't throw exceptions, throw it for them
                    throw new Exception(loginResult.Error);
                }

                var user = await VerifyAuth0LoginAsync(loginResult);

                
                _userInfoService.SetUserInfo(user);
                return user != null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

    }
}
