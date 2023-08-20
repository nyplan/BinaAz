using BinaAz.Application.DTOs.Item;
using MediatR;

namespace BinaAz.Application.Features.Commands.Item.UpdateItem.UpdateOffice;

public class UpdateOfficeCommandRequest : IRequest<UpdateOfficeCommandResponse>
{
    public ItemDto Dto { get; set; } = null!;
    public int ItemNumber { get; set; }
}