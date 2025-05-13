using Microsoft.AspNetCore.Mvc;
using RouteAggregator.Model.Services;

namespace RouteAggregator;

[Route("routes")]
public class RoutesController(IRouteAggregatorService routeAggregatorService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var results = await routeAggregatorService.GetRoutes();
        return Ok(results);
    }
}