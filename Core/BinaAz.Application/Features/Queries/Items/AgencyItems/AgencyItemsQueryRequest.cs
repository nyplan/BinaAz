using MediatR;

namespace BinaAz.Application.Features.Queries.Items.AgencyItems;

public class AgencyItemsQueryRequest : IRequest<AgencyItemsQueryResponse>
{
    public int Page { get; set; } = 0;
    public bool More { get; set; }
}