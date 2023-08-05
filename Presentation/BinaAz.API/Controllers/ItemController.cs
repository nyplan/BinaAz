using Azure.Core;
using BinaAz.Application.DTOs.Item.AddItem;
using BinaAz.Application.Features.Commands.Item.AddGarageRentItem;
using BinaAz.Application.Features.Queries.ItemImage.GetItemImage;
using BinaAz.Persistence.Contexts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        // for admins
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            return Ok();
        }

        
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddGarageRent([FromForm] AddGarageRentDto dto)
        {
            var response = await _mediator.Send(new AddGarageCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddGarageSale([FromForm] AddGarageSaleDto dto)
        {
            var response = await _mediator.Send(new AddGarageCommandRequest() { Dto = dto });
            return Ok(response);
        }

        //todo butun bina tipleri ucun burda add olacaq
        
        
        
        // todo bura kimi
        
        
        
        
        
        
        [HttpPost("[action]")]
        public async Task<IActionResult> GetItemImage([FromBody] GetItemImageQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return File(response.Stream, response.ContentType, $"item-{request.ItemNumber}");
        }
         
    }
}
