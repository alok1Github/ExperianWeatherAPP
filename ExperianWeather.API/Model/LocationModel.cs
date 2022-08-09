using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Experian.API.Model
{
    public class LocationModel
    {        
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Localtime { get; set; }   // To Do : DateTimeOffset -use custom pareser 

        [JsonPropertyName("localtime_epoch")]
        public int Localtimeepoch { get; set; }

    }
}
