using BinaAz.Application.Features.Commands.Balance.IncreaseBalance;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BinaAz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<IActionResult> IncreaseBalance([FromBody] IncreaseBalanceCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpPost]
        public async Task<IActionResult> MakeItemVip(string itemNumber)
        {
            return Ok();
        }
    }
}
