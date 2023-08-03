using BinaAz.Application.Features.Commands.ItemImage.UploadItemImage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BinaAz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery] UploadItemImageCommandRequest request)
        {
            request.Files = Request.Form.Files;
            await _mediator.Send(request);
            return Ok();
        }
    }
}
