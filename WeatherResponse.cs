namespace WeatherPRO
{
    public class WeatherResponse
    {
        public string? Summary { get; set; }
        public string? Client_ip { get; set; }
        public string? Location { get; set; }
        public string? Greeting { get; set; }
        public string? status { get; set; }
        public string? continent { get; set; }
        public string? country { get; set; }
        public string? regionName { get; set; }
        public string? city { get; set; }
        public string? district { get; set; }
        public string? zip { get; set; }
        public double? lat { get; set; }
        public double? lon { get; set; }
        public string? isp { get; set; }
        public string? query { get; set; }
    }
}
