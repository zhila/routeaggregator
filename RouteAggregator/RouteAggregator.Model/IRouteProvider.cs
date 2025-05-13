using System.Collections.Generic;
using System.Threading.Tasks;

namespace RouteAggregator.Model
{
    public interface IRouteProvider
    {
        Task<IEnumerable<RouteDto>> GetRoutes();
    }
}