using Auth0.OidcClient;
using ClientApp.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace ClientApp
{
    public static class Auth0Program
    {
        public static void SetupAuth0Authentication( this IServiceCollection services )
        {
            services.AddSingleton(new Auth0Client(new Auth0ClientOptions
            {
                Domain = "dev-2dnfqskv260fu3s8.us.auth0.com", // these strings are not confiedntial
                ClientId = "2UZ9v1sdCCzDDGxpLRErbrwVornwwr3O",
                Scope = "openid profile",
                RedirectUri = "myapp://callback/",
            }));

            services.AddAuthorizationCore();
            //services.AddScoped<AuthenticationStateProvider, Auth0AuthenticationStateProvider>();
            services.AddSingleton<LoginService>();
        }
    }
}
