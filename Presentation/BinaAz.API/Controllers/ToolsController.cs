using BinaAz.Application.Features.Queries.Tools.GetCities;
using BinaAz.Application.Features.Queries.Tools.GetDistricts;
using BinaAz.Application.Features.Queries.Tools.GetSettlements;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BinaAz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToolsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("cities")]
        public async Task<IActionResult> GetCities()
        {
            var response = await _mediator.Send(new GetCitiesQueryRequest());
            return Ok(response);
        }
        
        [HttpGet("districts")]
        public async Task<IActionResult> GetDistricts()
        {
            var response = await _mediator.Send(new GetDistrictsQueryRequest());
            return Ok(response);
        }
        
        [HttpGet("settlements")]
        public async Task<IActionResult> GetSettlements()
        {
            var response = await _mediator.Send(new GetSettlementsQueryRequest());
            return Ok(response);
        }
    }
}
