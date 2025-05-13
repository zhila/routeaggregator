using System.Collections.Generic;
using System.Threading.Tasks;

namespace RouteAggregator.Model
{
    public interface IRouteAggregatorService
    {
        Task<IEnumerable<RouteDto>> GetRoutes();
    }
}