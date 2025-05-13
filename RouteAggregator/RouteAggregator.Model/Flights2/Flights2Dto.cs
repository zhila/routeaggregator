using System.Text.Json.Serialization;

namespace RouteAggregator.Model.Flights2
{
    public class Flights2Dto
    {
        [JsonPropertyName("codeShare")]
        public string? CodeShare { get; set; }

        [JsonPropertyName("sourceAirport")]
        public string? SourceAirport { get; set; }

        [JsonPropertyName("equipment")]
        public string? Equipment { get; set; }

        [JsonPropertyName("stops")]
        public int? Stops { get; set; }

        [JsonPropertyName("airline")]
        public string? Airline { get; set; }

        [JsonPropertyName("destinationAirport")]
        public string? DestinationAirport { get; set; }
    }
}
