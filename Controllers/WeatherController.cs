using Microsoft.AspNetCore.Mvc;
using OpenMeteo;

namespace WeatherPRO.Controllers
{
    [Route("api/")]
    [ApiController]
    public class WeatherController(IpApiClient ipApiClient) : ControllerBase
    {
        private readonly IpApiClient _ipApiClient = ipApiClient;

        [HttpGet("Hello")]
        public async Task<IActionResult> Hello([FromQuery] string visitor_name, CancellationToken token)
        {
            if (string.IsNullOrEmpty(visitor_name))
            {
                return BadRequest();
            }

            var ipAddress = HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR") ?? HttpContext.Connection.RemoteIpAddress?.ToString();
            var ipAddressWithoutPort = ipAddress?.Split(':')[0];

            var ipApiResponse = await _ipApiClient.Get(ipAddressWithoutPort, token);

            string city = ipApiResponse?.city ?? "Abuja";

            OpenMeteoClient client = new OpenMeteoClient();
            WeatherForecast? weatherData = await client.QueryAsync(city);

            var temperature = weatherData?.Current?.Temperature;

            var response = new
            {
                Client_ip = ipApiResponse?.query,
                Location = ipApiResponse?.city,
                Greeting = $"Hello, {visitor_name}!, The temperature is {temperature} degrees Celsius in {ipApiResponse?.city}",
            };

            return Ok(response);
        }
    }
}
