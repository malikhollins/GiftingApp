using System.Text.Json;

namespace ClientApp.Utils
{
    public static class DeserializeResponse
    {
        private static readonly JsonSerializerOptions DeserializationOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public static async Task<T?> DeserializeAsync<T>(this HttpResponseMessage httpResponseMessage)
        {
            var json = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json ?? string.Empty, DeserializationOptions);
        }
    }
}
