using BinaAz.Application.DTOs.Item;
using MediatR;

namespace BinaAz.Application.Features.Commands.Item.AddItem.AddOldBuilding;

public class AddOldBuildingCommandRequest : IRequest<AddOldBuildingCommandResponse>
{
    public ItemToAddDto Dto { get; set; } = null!;
}