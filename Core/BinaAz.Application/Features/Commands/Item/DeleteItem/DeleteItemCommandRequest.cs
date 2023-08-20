using MediatR;

namespace BinaAz.Application.Features.Commands.Item.DeleteItem;

public class DeleteItemCommandRequest : IRequest<string>
{
    public int ItemNumber { get; set; }
}