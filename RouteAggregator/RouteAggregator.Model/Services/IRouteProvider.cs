using System.Collections.Generic;
using System.Threading.Tasks;
using RouteAggregator.Model.Dto;

namespace RouteAggregator.Model.Services
{
    public interface IRouteProvider
    {
        Task<IEnumerable<RouteDto>> GetRoutes();
    }
}