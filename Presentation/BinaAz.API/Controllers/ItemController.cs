using BinaAz.Application.DTOs.Item.AddUpdateItem;
using BinaAz.Application.Features.Commands.Item.AddItem.AddGarage;
using BinaAz.Application.Features.Commands.Item.AddItem.AddGardenHouse;
using BinaAz.Application.Features.Commands.Item.AddItem.AddGround;
using BinaAz.Application.Features.Commands.Item.AddItem.AddNewBuilding;
using BinaAz.Application.Features.Commands.Item.AddItem.AddObject;
using BinaAz.Application.Features.Commands.Item.AddItem.AddOffice;
using BinaAz.Application.Features.Commands.Item.AddItem.AddOldBuilding;
using BinaAz.Application.Features.Commands.Item.DeleteItem;
using BinaAz.Application.Features.Commands.Item.UpdateItem.UpdateGarage;
using BinaAz.Application.Features.Commands.Item.UpdateItem.UpdateGardenHouse;
using BinaAz.Application.Features.Commands.Item.UpdateItem.UpdateGround;
using BinaAz.Application.Features.Commands.Item.UpdateItem.UpdateNewBuilding;
using BinaAz.Application.Features.Commands.Item.UpdateItem.UpdateObject;
using BinaAz.Application.Features.Commands.Item.UpdateItem.UpdateOffice;
using BinaAz.Application.Features.Commands.Item.UpdateItem.UpdateOldBuilding;
using BinaAz.Application.Features.Commands.LikedItems.DislikeAnItem;
using BinaAz.Application.Features.Commands.LikedItems.LikeAnItem;
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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BinaAz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> Search([FromQuery] GeneralSearchCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        #region Main Page Items 

        [HttpGet("vip-items")]
        [AllowAnonymous]
        public async Task<IActionResult> VipItems([FromQuery] VipItemsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet("last-items")]
        [AllowAnonymous]
        public async Task<IActionResult> LastItems([FromQuery] LastItemsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet("agency-items")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAgencyItems([FromQuery] AgencyItemsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
         
        [HttpGet("residential-complexes")]
        [AllowAnonymous]
        public async Task<IActionResult> GetResidentialComplexes([FromQuery] ResidentialComplexItemsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet("premium-items")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPremiumItems([FromQuery] PremiumItemsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet("new-buildings")]
        [AllowAnonymous]
        public async Task<IActionResult> GetNewBuildings([FromQuery] NewBuildingsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet("old-buildings")]
        [AllowAnonymous]
        public async Task<IActionResult> GetOldBuildings([FromQuery] OldBuildingsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet("garden-houses")]
        [AllowAnonymous]
        public async Task<IActionResult> GetGardenHouses([FromQuery] GardenHousesQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("offices")]
        [AllowAnonymous]
        public async Task<IActionResult> GetOffices([FromQuery] OfficesQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpGet("garages")]
        [AllowAnonymous]
        public async Task<IActionResult> GetGarages([FromQuery] GaragesQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("grounds")]
        [AllowAnonymous]
        public async Task<IActionResult> GetGrounds([FromQuery] GroundsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("objects")]
        [AllowAnonymous]
        public async Task<IActionResult> GetObjects([FromQuery] ObjectsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        #endregion
        
        // .....................................................................................

        #region Add Item Commands
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddGarageRent([FromForm] GarageRentDto dto)
        {
            var response = await _mediator.Send(new AddGarageCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddGarageSale([FromForm] GarageSaleDto dto)
        {
            var response = await _mediator.Send(new AddGarageCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddGardenHouseRent([FromForm] GardenHouseRentDto dto)
        {
            var response = await _mediator.Send(new AddGardenHouseCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddGardenHouseSale([FromForm] GardenHouseSaleDto dto)
        {
            var response = await _mediator.Send(new AddGardenHouseCommandRequest() { Dto = dto });
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddGroundRent([FromForm] GroundRentDto dto)
        {
            var response = await _mediator.Send(new AddGroundCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddGroundSale([FromForm] GroundSaleDto dto)
        {
            var response = await _mediator.Send(new AddGroundCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddNewBuildingRent([FromForm] NewBuildingRentDto dto)
        {
            var response = await _mediator.Send(new AddNewBuildingCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddNewBuildingSale([FromForm] NewBuildingSaleDto dto)
        {
            var response = await _mediator.Send(new AddNewBuildingCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddObjectRent([FromForm] ObjectRentDto dto)
        {
            var response = await _mediator.Send(new AddObjectCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddObjectSale([FromForm] ObjectSaleDto dto)
        {
            var response = await _mediator.Send(new AddObjectCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddOfficeRent([FromForm] OfficeRentDto dto)
        {
            var response = await _mediator.Send(new AddOfficeCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddOfficeSale([FromForm] OfficeSaleDto dto)
        {
            var response = await _mediator.Send(new AddOfficeCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddOldBuildingRent([FromForm] OldBuildingRentDto dto)
        {
            var response = await _mediator.Send(new AddOldBuildingCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> AddOldBuildingSale([FromForm] OldBuildingSaleDto dto)
        {
            var response = await _mediator.Send(new AddOldBuildingCommandRequest() { Dto = dto });
            return Ok(response);
        }
        
        #endregion

        #region Update Item Commands

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateGarageRent([FromForm] GarageRentDto dto, int itemNumber)
        {
            var response = await _mediator.Send(new UpdateGarageCommandRequest()
                { Dto = dto, ItemNumber = itemNumber });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateGarageSale([FromForm] GarageSaleDto dto, int itemNumber)
        {
            var response = await _mediator.Send(new UpdateGarageCommandRequest()
                { Dto = dto, ItemNumber = itemNumber });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateGardenHouseRent([FromForm] GardenHouseRentDto dto, int itemNumber)
        {
            var response = await _mediator.Send(new UpdateGardenHouseCommandRequest() { Dto = dto, ItemNumber = itemNumber });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateGardenHouseSale([FromForm] GardenHouseSaleDto dto, int itemNumber)
        {
            var response = await _mediator.Send(new UpdateGardenHouseCommandRequest() { Dto = dto, ItemNumber = itemNumber });
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateGroundRent([FromForm] GroundRentDto dto, int itemNumber)
        {
            var response = await _mediator.Send(new UpdateGroundCommandRequest() { Dto = dto, ItemNumber = itemNumber });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateGroundSale([FromForm] GroundSaleDto dto, int itemNumber)
        {
            var response = await _mediator.Send(new UpdateGroundCommandRequest() { Dto = dto, ItemNumber = itemNumber });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateNewBuildingRent([FromForm] NewBuildingRentDto dto, int itemNumber)
        {
            var response = await _mediator.Send(new UpdateNewBuildingCommandRequest() { Dto = dto, ItemNumber = itemNumber });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateNewBuildingSale([FromForm] NewBuildingSaleDto dto, int itemNumber)
        {
            var response = await _mediator.Send(new UpdateNewBuildingCommandRequest() { Dto = dto, ItemNumber = itemNumber });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateObjectRent([FromForm] ObjectRentDto dto, int itemNumber)
        {
            var response = await _mediator.Send(new UpdateObjectCommandRequest() { Dto = dto, ItemNumber = itemNumber });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateObjectSale([FromForm] ObjectSaleDto dto, int itemNumber)
        {
            var response = await _mediator.Send(new UpdateObjectCommandRequest() { Dto = dto, ItemNumber = itemNumber });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateOfficeRent([FromForm] OfficeRentDto dto, int itemNumber)
        {
            var response = await _mediator.Send(new UpdateOfficeCommandRequest() { Dto = dto, ItemNumber = itemNumber });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateOfficeSale([FromForm] OfficeSaleDto dto, int itemNumber)
        {
            var response = await _mediator.Send(new UpdateOfficeCommandRequest() { Dto = dto, ItemNumber = itemNumber });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateOldBuildingRent([FromForm] OldBuildingRentDto dto, int itemNumber)
        {
            var response = await _mediator.Send(new UpdateOldBuildingCommandRequest() { Dto = dto, ItemNumber = itemNumber });
            return Ok(response);
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateOldBuildingSale([FromForm] OldBuildingSaleDto dto, int itemNumber)
        {
            var response = await _mediator.Send(new UpdateOldBuildingCommandRequest() { Dto = dto, ItemNumber = itemNumber });
            return Ok(response);
        }

        #endregion

        #region Delete Item Commands

        [HttpDelete]
        public async Task<IActionResult> DeleteItem([FromQuery] DeleteItemCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        #endregion

        #region LikeAndUnLikeItem

        [HttpPost("like-item")]
        public async Task<IActionResult> LikeAnItem([FromBody] LikeAnItemCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        
        [HttpPost("dislike-item")]
        public async Task<IActionResult> DislikeAnItem([FromBody] DislikeAnItemCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        #endregion
    }
}
