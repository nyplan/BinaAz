using BinaAz.Application.DTOs.Item;
using MediatR;

namespace BinaAz.Application.Features.Commands.Item.UpdateItem.UpdateGarage;

public class UpdateGarageCommandRequest : IRequest<UpdateGarageCommandResponse>
{
    public ItemDto Dto { get; set; } = null!;
    public int ItemNumber { get; set; }
}