namespace Experian.API.Request
{
    public class WeatherRequest : IRequest
    {
        public string City { get; set; }
        public string Country { get; set; }
        public bool AirQuality { get; set; }
        public TempratureEnum TempratureUnit { get; set; }
    }

    public enum TempratureEnum
    {
        Celsius,
        Fahrenheit
    }
}
