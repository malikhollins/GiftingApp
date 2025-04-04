using Auth0.OidcClient;
using ClientApp.Models;
using System.Diagnostics;

namespace ClientApp.Services
{
    public class LoginService
    {
        private readonly Auth0Client _authClient;
        private readonly HttpClient _httpClient;

        public LoginService(Auth0Client client, HttpClient httpClient)
        {
            _authClient = client;
            _httpClient = httpClient;
        }

        public async Task<bool> LoginAsync()
        {
            try
            {
                var loginResult = await _authClient.LoginAsync();


                if (loginResult.IsError)
                {
                    return false;
                }

                var wasCreated = loginResult.User.Claims.FirstOrDefault( claim => claim.Type == "app_metadata");
                var userId = loginResult.User.Claims.FirstOrDefault(claim => claim.Type == "sub");

                if (wasCreated != null && (bool.TryParse(wasCreated.Value, out var result) && result))
                {
                    var email = loginResult.User.Claims.FirstOrDefault(claim => claim.Type == "email");
                    var response = await _httpClient.GetAsync($"todos?userId={userId}/email={email}");
                    Debug.WriteLine(response);
                }
                else
                {
                    // fetch db
                    var response = await _httpClient.GetAsync($"todos?userId={userId}");
                    Debug.WriteLine(response);
                }

                return true;
            }
            catch (Exception ex) 
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

    }
}
