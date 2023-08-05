using BinaAz.Application.DTOs.Item;
using MediatR;

namespace BinaAz.Application.Features.Commands.Item.AddItem;

public class AddItemCommandRequest : IRequest<AddItemCommandResponse>
{
    public ItemToAddDto Dto { get; set; }
}