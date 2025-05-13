using System;
using System.Text.Json.Serialization;

namespace RouteAggregator.Model.Dto
{
    public class RouteDto : IEquatable<RouteDto>
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

        public bool Equals(RouteDto? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return Airline == other.Airline && SourceAirport == other.SourceAirport && DestinationAirport == other.DestinationAirport && CodeShare == other.CodeShare && Stops == other.Stops && Equipment == other.Equipment;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((RouteDto)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Airline, SourceAirport, DestinationAirport, CodeShare, Stops, Equipment);
        }
    }
}