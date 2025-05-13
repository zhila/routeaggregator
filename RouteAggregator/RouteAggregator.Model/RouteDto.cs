using System.Text.Json.Serialization;

namespace RouteAggregator.Model
{
    public class RouteDto
    {
        [JsonPropertyName("airline")]
        public string Airline { get; set; }

        [JsonPropertyName("sourceAirport")]
        public string SourceAirport { get; set; }

        [JsonPropertyName("destinationAirport")]
        public string DestinationAirport { get; set; }

        [JsonPropertyName("codeShare")]
        public string CodeShare { get; set; }

        [JsonPropertyName("stops")]
        public int Stops { get; set; }

        [JsonPropertyName("equipment")]
        public string? Equipment { get; set; }
    }
}