# WeatherPRO

WeatherPRO is an ASP.NET Core web API that provides weather information based on the client's IP address. The API returns a personalized greeting along with the current temperature in the client's location.

## Features
- Retrieves the client's IP address and location.
- Fetches current weather data for the client's location.
- Returns a personalized greeting with the current temperature.

## Third-Party APIs
### OpenMeteo
Used to fetch temperature.

### Ip-API
Used to determine the client's location based on their IP address.

Both APIs were chosen because they offer no-key free plans.

## Endpoints
### GET /api/Hello
Retrieves a personalized greeting with the current temperature.

**Parameters**
- `visitor_name` (query): The name of the visitor (string).

**Response**
- `200 OK`: Returns a greeting message with the current temperature.
- `400 Bad Request`: Returns an error message if `visitor_name` is null or empty.

**Example Request**
```bash
GET /api/Hello?visitor_name=Kevin

```json
{
  "client_ip": "102.88.83.162",
  "location": "Lagos",
  "greeting": "Hello, Kevin!, The temperature is 27.6 degrees Celsius in Lagos"
}
