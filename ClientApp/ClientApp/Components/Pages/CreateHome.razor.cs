using ClientApp.Models;
using ClientApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace ClientApp.Components.Pages
{
    public partial class CreateHome
    {
        [Inject] HouseService HouseService { get; set; } = null!;

        public House HouseData { get; set; } = null!;
        public EditContext? EditContext { get; set; }
        public string MessageStore { get; set; } = "";

        protected override void OnInitialized()
        {
            HouseData = new House();
            EditContext = new EditContext(HouseData);
        }

        public async Task Submit()
        {
            MessageStore = $"{HouseData.Email} joined House {HouseData.HouseName}";
            var house = await HouseService.CreateHouseAsync(HouseData);

            Console.WriteLine(house.ToString());

            // reset house data
            HouseData = new House();
        }
    }
}
