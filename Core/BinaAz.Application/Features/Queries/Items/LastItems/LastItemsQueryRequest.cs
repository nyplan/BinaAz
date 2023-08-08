using MediatR;

namespace BinaAz.Application.Features.Queries.Items.LastItems;

public class LastItemsQueryRequest : IRequest<LastItemsQueryResponse>
{
    public int Page { get; set; } = 0;
    public bool More { get; set; }
}