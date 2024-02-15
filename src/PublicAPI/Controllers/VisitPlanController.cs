using KOF.RouteMap.Application.Common.Models;
using KOF.RouteMap.Application.VisitPlan.Queries.GetVisitPlanWithPagination;
using Microsoft.AspNetCore.Mvc;

namespace KOF.RouteMap.API.Controllers;

public class VisitPlanController : ApiControllerBase
{
    private readonly ILogger<VisitPlanController> _logger;

    public VisitPlanController(ILogger<VisitPlanController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<VisitPlanDto>>> GetVisitPlanWithPagination([FromQuery] GetVisitPlanWithPaginationQuery query)
    {
        try
        {
            _logger.LogInformation("Value requested: {query}", query);
            return Ok(await Mediator.Send(query));
        }
        catch (Exception ex)
        {
            // Log the exception
            _logger.LogError(ex, "An error occurred while processing the request.");
            return StatusCode(500, "An error occurred.");
        }
    }

}

