using System.Text.Json.Serialization;

namespace RouteAggregator.Model.Dto
{
    public class Flights1Dto
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
