using System.Collections.Generic;
using System.Threading.Tasks;
using RouteAggregator.Model.Dto;

namespace RouteAggregator.Model.Services
{
    public interface IRouteAggregatorService
    {
        Task<IEnumerable<RouteDto>> GetRoutes();
    }
}