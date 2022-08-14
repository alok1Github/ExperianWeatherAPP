namespace Experian.API.Request
{
    public class ConfigRequest : IRequest
    {
        public string BaseUrl { get; set; }
        public string Key { get; set; }
    }
    public class WeatherConfigRequest : ConfigRequest
    {
    }

    public class CityConfigRequest : ConfigRequest
    {
    }
}
