using System.Text.Json.Serialization;


namespace Experian.API.Model
{
    public class CityModel : IModel
    {
        public List<CityResult> cities { get; set; }
    }

    public class CityResult
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
