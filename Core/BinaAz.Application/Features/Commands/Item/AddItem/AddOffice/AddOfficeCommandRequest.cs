using BinaAz.Application.DTOs.Item;
using MediatR;

namespace BinaAz.Application.Features.Commands.Item.AddItem.AddOffice;

public class AddOfficeCommandRequest : IRequest<AddOfficeCommandResponse>
{
    public ItemDto Dto { get; set; } = null!;
}