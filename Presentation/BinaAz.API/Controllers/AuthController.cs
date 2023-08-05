using BinaAz.Application.Features.Commands.User.LoginUser;
using BinaAz.Application.Features.Commands.User.RefreshLogin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BinaAz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest request)
        {
            LoginUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet("[action]")]
        public async Task<IActionResult> RefreshLogin([FromQuery] RefreshLoginCommandRequest request)
        {
            RefreshLoginCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
