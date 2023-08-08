using MediatR;

namespace BinaAz.Application.Features.Queries.Items.PremiumItems;

public class PremiumItemsQueryRequest : IRequest<PremiumItemsQueryResponse>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 20;
}