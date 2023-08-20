using BinaAz.Application.DTOs.Item;
using MediatR;

namespace BinaAz.Application.Features.Commands.Item.AddItem.AddGarage;

public class AddGarageCommandRequest : IRequest<AddGarageCommandResponse>
{
    public ItemDto Dto { get; set; } = null!;
}