using BinaAz.Application.DTOs.Item.AddItem;
using MediatR;

namespace BinaAz.Application.Features.Commands.Item.AddNewBuildingRentItem;

public class AddNewBuildingRentItemCommandRequest : IRequest<AddNewBuildingRentItemCommandResponse>
{
    public AddNewBuildingRentDto Dto { get; set; }
}