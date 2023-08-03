using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BinaAz.Application.Features.Commands.User.LoginUser;
using BinaAz.Application.Features.Commands.User.RefreshLogin;
using BinaAz.Domain.Entities;
using MediatR;
using MessageBird;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

        
        
        

        // static Client client = Client.CreateDefault("AL9G01ibCmCN8AflHLKNpq6vXxNQNvMTlhJm");
        // [HttpPost("login-with-phone-number")]
        // public async Task<IActionResult> LoginWithNumber()
        // {
        //     const long Number = +994557673425; // your phone number
        //
        //     MessageBird.Objects.Message message =
        //         client.SendMessage("MessageBird", "Hi! This is your first message", new[] { Number });
        //     return Ok();
        // }
        //
        // [HttpPost("login-with-email")]
        // public async Task<IActionResult> LoginWithEmail()
        // {
        //     return Ok();
        // }
        //
        //[HttpPost("l")]
    }
}
