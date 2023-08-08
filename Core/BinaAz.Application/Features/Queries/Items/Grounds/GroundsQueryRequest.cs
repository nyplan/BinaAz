using MediatR;

namespace BinaAz.Application.Features.Queries.Items.Grounds;

public class GroundsQueryRequest : IRequest<GroundsQueryResponse>
{
    public int Page { get; set; }
    public bool More { get; set; }
    public bool IsRent { get; set; }
}