using ClientApp.Models;
using ClientApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace ClientApp.Components.Pages
{
    public partial class Home
    {
        [Inject] LoginService LoginService { get; set; } = null!;

        public GiftHouse? GiftHouseData { get; set; }
        public EditContext? EditContext { get; set; }
        public string MessageStore { get; set; } = "";

        private bool _isLoggingIn = false;

        protected override void OnInitialized()
        {
            GiftHouseData = new GiftHouse();
            EditContext = new EditContext(GiftHouseData);
        }

        public void Submit()
        {
            MessageStore = $"{GiftHouseData?.CreatorName} created House {GiftHouseData?.HouseName}";
            GiftHouseData = new GiftHouse();
        }

        public async void Login()
        {
            if (_isLoggingIn) 
            {
                return;
            }

            try
            {
                _isLoggingIn = true;

                await LoginService.LoginAsync();
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
