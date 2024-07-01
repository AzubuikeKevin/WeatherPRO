namespace WeatherPRO
{
    public class IpApiClient(HttpClient httpClient)
    {
        private const string BASE_URL = "http://ip-api.com";
        private readonly HttpClient _httpClient = httpClient;

        public async Task<WeatherResponse?> Get(string? ipAddress, CancellationToken token)
        {
            var route = $"{BASE_URL}/json/{ipAddress}";
            var response = await _httpClient.GetFromJsonAsync<WeatherResponse>(route, token);

            return response;
        }
    }
}
