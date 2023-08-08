using MediatR;

namespace BinaAz.Application.Features.Queries.Items.VipItems;

public class VipItemsQueryRequest : IRequest<VipItemsQueryResponse>
{
    public int Page { get; set; } = 0;
    public bool More { get; set; }
}