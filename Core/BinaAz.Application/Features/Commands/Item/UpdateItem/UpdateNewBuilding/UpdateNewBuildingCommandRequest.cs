using BinaAz.Application.DTOs.Item;
using MediatR;

namespace BinaAz.Application.Features.Commands.Item.UpdateItem.UpdateNewBuilding;

public class UpdateNewBuildingCommandRequest : IRequest<UpdateNewBuildingCommandResponse>
{
    public ItemDto Dto { get; set; } = null!;
    public int ItemNumber { get; set; }
}