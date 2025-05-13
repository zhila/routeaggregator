using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAggregator.Model.Dto;
using RouteAggregator.Model.Services;

namespace RouteAggregator.Services
{
    public class RouteAggregatorService : IRouteAggregatorService
    {
        private readonly IEnumerable<IRouteProvider> _providers;

        public RouteAggregatorService(IEnumerable<IRouteProvider> providers)
        {
            _providers = providers;
        }

        public async Task<IEnumerable<RouteDto>> GetRoutes()
        {
            IEnumerable<RouteDto> aggregatedResults = new List<RouteDto>();
            var providersResults = await Task.WhenAll(
                _providers.Select(p => p.GetRoutes()));

            foreach (var providerResult in providersResults.
                         Where(p => p != null))
            {
                aggregatedResults = aggregatedResults.Union(providerResult);
            }

            return aggregatedResults.Distinct();
        }
    }
}
