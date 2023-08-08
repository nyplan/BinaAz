using BinaAz.Application.Features.Commands.Balance.IncreaseBalance;
using BinaAz.Application.Features.Commands.Subscriptions.Premium;
using BinaAz.Application.Features.Commands.Subscriptions.VIP;
using MediatR;
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
        public async Task<IActionResult> IncreaseBalance([FromBody] IncreaseBalanceCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpPost("vip")]
        public async Task<IActionResult> MakeItemVip([FromQuery] MakeItemVipCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpPost("premium")]
        public async Task<IActionResult> MakeItemPremium([FromQuery] MakeItemPremiumCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
