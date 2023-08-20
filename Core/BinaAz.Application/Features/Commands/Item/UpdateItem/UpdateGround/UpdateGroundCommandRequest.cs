using BinaAz.Application.DTOs.Item;
using MediatR;

namespace BinaAz.Application.Features.Commands.Item.UpdateItem.UpdateGround;

public class UpdateGroundCommandRequest : IRequest<UpdateGroundCommandResponse>
{
    public ItemDto Dto { get; set; } = null!;
    public int ItemNumber { get; set; }
}