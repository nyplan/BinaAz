using BinaAz.Application.DTOs.Item.AddItem;
using BinaAz.Application.Features.Commands.Item.AddItem.AddGarage;
using BinaAz.Application.Features.Commands.Item.AddItem.AddGardenHouse;
using BinaAz.Application.Features.Commands.Item.AddItem.AddGround;
using BinaAz.Application.Features.Commands.Item.AddItem.AddNewBuilding;
using BinaAz.Application.Features.Commands.Item.AddItem.AddObject;
using BinaAz.Application.Features.Commands.Item.AddItem.AddOffice;
using BinaAz.Application.Features.Commands.Item.AddItem.AddOldBuilding;
using BinaAz.Application.Features.Queries.ItemImage.GetItemImage;
using BinaAz.Application.Features.Queries.Items.AgencyItems;
using BinaAz.Application.Features.Queries.Items.Garages;
using BinaAz.Application.Features.Queries.Items.GardenHouses;
using BinaAz.Application.Features.Queries.Items.GeneralSearch;
using BinaAz.Application.Features.Queries.Items.Grounds;
using BinaAz.Application.Features.Queries.Items.LastItems;
using BinaAz.Application.Features.Queries.Items.NewBuildings;
using BinaAz.Application.Features.Queries.Items.Objects;
using BinaAz.Application.Features.Queries.Items.Offices;
using BinaAz.Application.Features.Queries.Items.OldBuildings;
using BinaAz.Application.Features.Queries.Items.PremiumItems;
using BinaAz.Application.Features.Queries.Items.ResidentialComplexItems;
using BinaAz.Application.Features.Queries.Items.VipItems;
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

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] GeneralSearchCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        #region Main Page Items 

        [HttpGet("vip-items")]
        public async Task<IActionResult> VipItems([FromQuery] VipItemsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet("last-items")]
        public async Task<IActionResult> LastItems([FromQuery] LastItemsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet("agency-items")]
        public async Task<IActionResult> GetAgencyItems([FromQuery] AgencyItemsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
         
        [HttpGet("residential-complexes")]
        public async Task<IActionResult> GetResidentialComplexes(ResidentialComplexItemsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet("premium-items")]
        public async Task<IActionResult> GetPremiumItems(PremiumItemsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet("new-buildings")]
        public async Task<IActionResult> GetNewBuildings(NewBuildingsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet("old-buildings")]
        public async Task<IActionResult> GetOldBuildings(OldBuildingsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet("garden-houses")]
        public async Task<IActionResult> GetGardenHouses(GardenHousesQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("offices")]
        public async Task<IActionResult> GetOffices(OfficesQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet("garages")]
        public async Task<IActionResult> GetGarages(GaragesQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("grounds")]
        public async Task<IActionResult> GetGrounds(GroundsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("objects")]
        public async Task<IActionResult> GetObjects(ObjectsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        #endregion
        
        // .....................................................................................

        #region Add Item Commands
        
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
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddGardenHouseRent([FromForm] AddGardenHouseRentDto dto)
        {
            var response = await _mediator.Send(new AddGardenHouseCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddGardenHouseSale([FromForm] AddGarageSaleDto dto)
        {
            var response = await _mediator.Send(new AddGardenHouseCommandRequest() { Dto = dto });
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddGroundRent([FromForm] AddGroundRentDto dto)
        {
            var response = await _mediator.Send(new AddGroundCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddGroundSale([FromForm] AddGroundSaleDto dto)
        {
            var response = await _mediator.Send(new AddGroundCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddNewBuildingRent([FromForm] AddNewBuildingRentDto dto)
        {
            var response = await _mediator.Send(new AddNewBuildingCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddNewBuildingSale([FromForm] AddNewBuildingSaleDto dto)
        {
            var response = await _mediator.Send(new AddNewBuildingCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddObjectRent([FromForm] AddObjectRentDto dto)
        {
            var response = await _mediator.Send(new AddObjectCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddObjectSale([FromForm] AddObjectSaleDto dto)
        {
            var response = await _mediator.Send(new AddObjectCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddOfficeRent([FromForm] AddOfficeRentDto dto)
        {
            var response = await _mediator.Send(new AddOfficeCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddOfficeSale([FromForm] AddOfficeSaleDto dto)
        {
            var response = await _mediator.Send(new AddOfficeCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddOldBuildingRent([FromForm] AddOldBuildingRentDto dto)
        {
            var response = await _mediator.Send(new AddOldBuildingCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddOldBuildingSale([FromForm] AddOldBuildingSaleDto dto)
        {
            var response = await _mediator.Send(new AddOldBuildingCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        #endregion

        
        
        [HttpPost("[action]")]
        public async Task<IActionResult> GetItemImage([FromBody] GetItemImageQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return File(response.Stream, response.ContentType, $"item-{request.ItemNumber}");
        }
    }
}
