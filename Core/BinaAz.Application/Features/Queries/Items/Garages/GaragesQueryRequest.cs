using MediatR;

namespace BinaAz.Application.Features.Queries.Items.Garages;

public class GaragesQueryRequest : IRequest<GaragesQueryResponse>
{
    public int Page { get; set; }
    public bool More { get; set; }
    public bool IsRent { get; set; }
}