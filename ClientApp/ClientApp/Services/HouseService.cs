
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text.Json;

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
            // Parse JSON response deserialize into Todo type
            var response = await _httpClient.GetAsync($"todos?userId={userId}");
        }

        public void Dispose() => _httpClient?.Dispose();
    }
}
