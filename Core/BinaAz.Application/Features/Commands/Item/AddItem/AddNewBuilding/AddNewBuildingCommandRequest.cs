using BinaAz.Application.DTOs.Item;
using MediatR;

namespace BinaAz.Application.Features.Commands.Item.AddItem.AddNewBuilding;

public class AddNewBuildingCommandRequest : IRequest<AddNewBuildingCommandResponse>
{
    public ItemToAddDto Dto { get; set; } = null!;
}