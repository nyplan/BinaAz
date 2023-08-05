using BinaAz.Application.DTOs.Item;
using MediatR;

namespace BinaAz.Application.Features.Commands.Item.AddGarageRentItem;

public class AddGarageCommandRequest : IRequest<AddGarageCommandResponse>
{
    public ItemToAddDto Dto { get; set; } = null!;
}