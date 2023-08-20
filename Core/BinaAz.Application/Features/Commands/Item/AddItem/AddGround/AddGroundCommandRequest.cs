using BinaAz.Application.DTOs.Item;
using MediatR;

namespace BinaAz.Application.Features.Commands.Item.AddItem.AddGround;

public class AddGroundCommandRequest : IRequest<AddGroundCommandResponse>
{
    public ItemDto Dto { get; set; } = null!;
}