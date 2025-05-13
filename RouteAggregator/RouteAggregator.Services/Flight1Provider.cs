using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using RouteAggregator.Model;
using RouteAggregator.Model.Flights1;

namespace RouteAggregator.Services
{
    public class Flight1Provider : IRouteProvider
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IApplicationConfiguration _applicationConfiguration;

        public Flight1Provider(IHttpClientFactory clientFactory, IApplicationConfiguration applicationConfiguration)
        {
            _clientFactory = clientFactory;
            _applicationConfiguration = applicationConfiguration;
        }

        public async Task<IEnumerable<RouteDto>> GetRoutes()
        {
            HttpClient client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(_applicationConfiguration.Flights1Url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{nameof(Flight1Provider)} call failed with status code: {response.StatusCode}");
            }

            var result = await response.Content.ReadAsStringAsync();
            try
            {
                var results = JsonSerializer.Deserialize<IEnumerable<Flights1Dto>>(result);
                return Map(results);
            }
            catch(SerializationException)
            {
                throw new Exception("Unable to deserialize Flights1 response");
            }
        }

        private IEnumerable<RouteDto> Map(IEnumerable<Flights1Dto> input)
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