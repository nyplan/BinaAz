using MediatR;

namespace BinaAz.Application.Features.Queries.Items.Offices;

public class OfficesQueryRequest : IRequest<OfficesQueryResponse>
{
    public int Page { get; set; }
    public bool More { get; set; }
    public bool IsRent { get; set; }
}