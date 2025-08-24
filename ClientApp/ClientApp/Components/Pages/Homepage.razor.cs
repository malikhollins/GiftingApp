
using ClientApp.Models;
using ClientApp.Services;
using Microsoft.AspNetCore.Components;

namespace ClientApp.Components.Pages
{
    public partial class Homepage
    {
        [Inject] HouseService HouseService { get; set; } = null!;
        public IEnumerable<House> Houses { get; set; } = null!;

        public bool HasNoHouses => !Houses?.Any() ?? true;

        protected override async Task OnInitializedAsync()
        {
            Houses = await HouseService.GetHousesAsync();
            await base.OnInitializedAsync();
        }
    }
}
