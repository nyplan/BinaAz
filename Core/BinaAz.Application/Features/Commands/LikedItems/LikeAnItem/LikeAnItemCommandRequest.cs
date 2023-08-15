using MediatR;

namespace BinaAz.Application.Features.Commands.LikedItems.LikeAnItem;

public class LikeAnItemCommandRequest : IRequest<bool>
{
    public int ItemNumber { get; set; }
}