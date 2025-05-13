using System.Collections.Generic;
using System.Net.Http;
using RouteAggregator.Model;
using RouteAggregator.Model.Dto;

namespace RouteAggregator.Services
{
    public class Flight1Provider : BaseRouteProvider<Flights1Dto>
    {
        public Flight1Provider(IHttpClientFactory clientFactory, IApplicationConfiguration applicationConfiguration) :
            base(clientFactory, applicationConfiguration)
        {
        }

        protected override string ApiUrl => ApplicationConfiguration.Flights2Url;

        protected override IEnumerable<RouteDto> Map(IEnumerable<Flights1Dto> input)
        {
            var results = new List<RouteDto>();
            foreach (var flights1Dto in input)
            {
                results.Add(new RouteDto
                {
                    Airline = flights1Dto.Airline,
                    CodeShare = flights1Dto.CodeShare,
                    DestinationAirport = flights1Dto.DestinationAirport,
                    Equipment = flights1Dto.Equipment,
                    SourceAirport = flights1Dto.SourceAirport,
                    Stops = flights1Dto.Stops.GetValueOrDefault()
                });
            }

            return results;
        }
    }
}