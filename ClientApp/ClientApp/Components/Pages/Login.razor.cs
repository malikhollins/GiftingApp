using ClientApp.Services;
using Microsoft.AspNetCore.Components;

namespace ClientApp.Components.Pages
{
    public partial class Login
    {
        [Inject] LoginService LoginService { get; set; } = null!;
        [Inject] NavigationManager NavigationManager { get; set; } = null!;

        private bool _isLoggingIn = false;

        public async void OnLoginClickedAsync()
        {
            if (_isLoggingIn)
            {
                return;
            }

            try
            {
                _isLoggingIn = true;
                bool loggedIn = await LoginService.LoginAsync();
                if (loggedIn)
                {
                    NavigationManager.NavigateTo("/homepage");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _isLoggingIn = false;
            }
        }
    }
}
