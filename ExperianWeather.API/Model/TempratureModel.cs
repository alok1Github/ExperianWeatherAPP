using System.Text.Json.Serialization;

namespace Experian.API.Model
{
    public class TempratureModel
    {
        [JsonPropertyName("last_updated_epoch")]
        public int LastUpdatedEpoch { get; set; }

        [JsonPropertyName("last_updated")]
        public string LastUpdated { get; set; }

        [JsonPropertyName("temp_c")]
        public decimal TempratureInCelsius { get; set; }

        [JsonPropertyName("temp_f")]
        public decimal TempFahrenheit { get; set; }

        public decimal Temprature { get; set; }

        [JsonPropertyName("condition")]
        public ConditionModel ConditionDetails { get; set; }

    }
}
