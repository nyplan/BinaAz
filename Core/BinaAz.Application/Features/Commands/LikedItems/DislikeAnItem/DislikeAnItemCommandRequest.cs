using MediatR;

namespace BinaAz.Application.Features.Commands.LikedItems.DislikeAnItem;

public class DislikeAnItemCommandRequest : IRequest<bool>
{
    public int ItemNumber { get; set; }
}