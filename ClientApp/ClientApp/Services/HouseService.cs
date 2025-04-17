

namespace ClientApp.Services
{
    public class HouseService : IDisposable
    {
        private readonly HttpClient _httpClient;

        public HouseService( HttpClient httpClient ) 
        {
            _httpClient = httpClient;
        }

        public async Task GetUserHouseAsync(int userId)
        {
            // Make HTTP GET request
            // Parse JSON response deserialize into house type
            var response = await _httpClient.GetAsync($"api/House/{userId}");
        }

        public void Dispose() => _httpClient?.Dispose();
    }
}
