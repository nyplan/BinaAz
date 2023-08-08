using BinaAz.Application.DTOs.Item;
using MediatR;

namespace BinaAz.Application.Features.Commands.Item.AddItem.AddGardenHouse;

public class AddGardenHouseCommandRequest : IRequest<AddGardenHouseCommandResponse>
{
    public ItemToAddDto Dto { get; set; } = null!;
}