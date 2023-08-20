using BinaAz.Application.DTOs.User;
using BinaAz.Application.Features.Commands.Profile.UpdateProfile;
using BinaAz.Application.Features.Commands.User.RegisterWithEmail;
using BinaAz.Application.Features.Commands.User.RegisterWithPhone;
using BinaAz.Application.Features.Commands.User.SwitchToAgency;
using BinaAz.Application.Features.Commands.User.SwitchToResidentialComplex;
using BinaAz.Application.Features.Commands.User.UpdateProfilePhoto;
using BinaAz.Application.Features.Queries.Profile.GetMe;
using BinaAz.Application.Features.Queries.Profile.GetMyItems;
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

        #endregion

        #region SwitchTo

        [HttpPut("switch-to-agency")]
        public async Task<IActionResult> SwitchToAgency([FromBody] SwitchToAgencyCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpPut("switch-to-residential-complex")]
        public async Task<IActionResult> SwitchToResidentialComplex([FromBody] SwitchToResidentialComplexCommandRequest request)
        {
            var response = await _mediator.Send(request);
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

        [HttpPut("update-profile")]
        public async Task<IActionResult> UpdateProfile([FromQuery] UpdateProfileCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("update-profile-photo")]
        public async Task<IActionResult> UpdateProfilePicture([FromForm] UpdateProfilePhotoCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("my-items")]
        public async Task<IActionResult> MyItems([FromQuery] GetMyItemsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        #endregion
    }
}
