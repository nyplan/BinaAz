using BinaAz.Application.DTOs.Item;
using MediatR;

namespace BinaAz.Application.Features.Commands.Item.UpdateItem.UpdateGardenHouse;

public class UpdateGardenHouseCommandRequest : IRequest<UpdateGardenHouseCommandResponse>
{
    public ItemDto Dto { get; set; } = null!;
    public int ItemNumber { get; set; }
}