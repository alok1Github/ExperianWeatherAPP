using System.Text.Json.Serialization;

namespace Experian.API.Model
{
    public class TempratureModel
    {
        [JsonPropertyName("last_updated_epoch")]
        public int LastUpdatedEpoch { get; set; }

        [JsonPropertyName("last_updated")]
        public string LastUpdated { get; set; }  // To Do : DateTimeOffset -use custom pareser

        [JsonPropertyName("temp_c")]
        public decimal TempratureIncelsius { get; set; }

        [JsonPropertyName("temp_f")]
        public decimal TempFahrenheit { get; set; }

        [JsonPropertyName("condition")]
        public ConditionModel ConditionDetails { get; set; }

    }
}
