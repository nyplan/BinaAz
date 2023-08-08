using BinaAz.Application.DTOs.User;
using BinaAz.Application.Features.Commands.Profile.UpdateProfile;
using BinaAz.Application.Features.Commands.User.RegisterWithEmail;
using BinaAz.Application.Features.Commands.User.RegisterWithEmailAgency;
using BinaAz.Application.Features.Commands.User.RegisterWithEmailResident;
using BinaAz.Application.Features.Commands.User.RegisterWithPhone;
using BinaAz.Application.Features.Commands.User.RegisterWithPhoneAgency;
using BinaAz.Application.Features.Commands.User.RegisterWithPhoneResident;
using BinaAz.Application.Features.Queries.Profile.GetMe;
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

        #region Registration

        [HttpPost("register-with-phone-user")]
        public async Task<IActionResult> RegisterAsUserWithPhone([FromBody] RegisterWithPhoneDto dto)
        {
            var response = await _mediator.Send(new RegisterWithPhoneCommandRequest() { Dto = dto});
            return Ok(response);
        }

        [HttpPost("register-with-email-user")]
        public async Task<IActionResult> RegisterAsUserWithEmail([FromBody] RegisterWithEmailDto dto)
        {
            var response = await _mediator.Send(new RegisterWithEmailCommandRequest() { Dto = dto });
            return Ok(response);
        }

        [HttpPost("register-with-email-agency")]
        public async Task<IActionResult> RegisterAsAgencyWithEmail([FromBody] RegisterAsAgencyEmailDto dto)
        {
            var response = await _mediator.Send(new RegisterWithEmailAgencyCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("register-with-phone-agency")]
        public async Task<IActionResult> RegisterAsAgencyWithPhone([FromBody] RegisterAsAgencyPhoneDto dto)
        {
            var response = await _mediator.Send(new RegisterWithPhoneAgencyCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("register-with-email-resident")]
        public async Task<IActionResult> RegisterAsResidentWithEmail([FromBody] RegisterAsResidentialComplexEmailDto dto)
        {
            var response = await _mediator.Send(new RegisterWithEmailResidentCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("register-with-phone-resident")]
        public async Task<IActionResult> RegisterAsResidentWithPhone([FromBody] RegisterAsResidentialComplexPhoneDto dto)
        {
            var response = await _mediator.Send(new RegisterWithPhoneResidentCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        #endregion

        #region Profile

        [HttpPost("me")]
        public async Task<IActionResult> GetMe([FromBody] GetMeQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateProfile([FromQuery] UpdateUserProfileCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        

        #endregion
    }
}
