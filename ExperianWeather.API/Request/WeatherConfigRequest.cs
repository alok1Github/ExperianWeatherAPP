namespace Experian.API.Request
{
    public class WeatherConfigRequest : IRequest
    {
        public string BaseUrl { get; set; }
        public string Key { get; set; }
    }
}
