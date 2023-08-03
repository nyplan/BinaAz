using BinaAz.Application.DTOs.User;
using BinaAz.Application.Features.Commands.User.RegisterWithEmail;
using BinaAz.Application.Features.Commands.User.RegisterWithPhone;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BinaAz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("register-with-phone")]
        public async Task<IActionResult> RegisterWithPhone([FromBody] RegisterWithPhoneDto dto)
        {
            var response = await _mediator.Send(new RegisterWithPhoneCommandRequest() { Dto = dto});
            return Ok(response);
        }

        [HttpPost("register-with-email")]
        public async Task<IActionResult> RegisterWithEmail([FromBody] RegisterWithEmailDto dto)
        {
            var response = await _mediator.Send(new RegisterWithEmailCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
    }
}
