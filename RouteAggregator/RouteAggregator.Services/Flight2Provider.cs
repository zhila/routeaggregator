using System.Collections.Generic;
using System.Net.Http;
using RouteAggregator.Model;
using RouteAggregator.Model.Dto;

namespace RouteAggregator.Services
{
    public class Flight2Provider : BaseRouteProvider<Flights2Dto>
    {
        public Flight2Provider(IHttpClientFactory clientFactory, IApplicationConfiguration applicationConfiguration) : base(clientFactory, applicationConfiguration)
        {
        }

        protected override string ApiUrl => ApplicationConfiguration.Flights2Url;

        protected override IEnumerable<RouteDto> Map(IEnumerable<Flights2Dto> input)
        {
            var results = new List<RouteDto>();
            foreach (var flights2Dto in input)
            {
                results.Add(new RouteDto
                {
                    Airline = flights2Dto.Airline,
                    CodeShare = flights2Dto.CodeShare,
                    DestinationAirport = flights2Dto.DestinationAirport,
                    Equipment = flights2Dto.Equipment,
                    SourceAirport = flights2Dto.SourceAirport,
                    Stops = flights2Dto.Stops.GetValueOrDefault()
                });
            }

            return results;
        }
    }
}