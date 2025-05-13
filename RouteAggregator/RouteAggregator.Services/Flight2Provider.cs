using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using RouteAggregator.Model;
using RouteAggregator.Model.Flights2;

namespace RouteAggregator.Services
{
    public class Flight2Provider : IRouteProvider
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IApplicationConfiguration _applicationConfiguration;

        public Flight2Provider(IHttpClientFactory clientFactory, IApplicationConfiguration applicationConfiguration)
        {
            _clientFactory = clientFactory;
            _applicationConfiguration = applicationConfiguration;
        }

        public async Task<IEnumerable<RouteDto>> GetRoutes()
        {
            HttpClient client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(_applicationConfiguration.Flights2Url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{nameof(Flight2Provider)} call failed with status code: {response.StatusCode}");
            }

            var result = await response.Content.ReadAsStringAsync();
            try
            {
                var results = JsonSerializer.Deserialize<IEnumerable<Flights2Dto>>(result);
                return Map(results);
            }
            catch (SerializationException)
            {
                throw new Exception("Unable to deserialize Flights2 response");
            }
        }

        private IEnumerable<RouteDto> Map(IEnumerable<Flights2Dto> input)
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