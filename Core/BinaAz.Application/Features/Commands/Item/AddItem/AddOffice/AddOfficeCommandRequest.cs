using BinaAz.Application.DTOs.Item;
using MediatR;

namespace BinaAz.Application.Features.Commands.Item.AddItem.AddOffice;

public class AddOfficeCommandRequest : IRequest<AddOfficeCommandResponse>
{
    public ItemToAddDto Dto { get; set; } = null!;
}