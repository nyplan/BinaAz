using BinaAz.Application.DTOs.Item;
using MediatR;

namespace BinaAz.Application.Features.Commands.Item.AddItem.AddObject;

public class AddObjectCommandRequest : IRequest<AddObjectCommandResponse>
{
    public ItemToAddDto Dto { get; set; } = null!;
}