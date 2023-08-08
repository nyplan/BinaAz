using MediatR;

namespace BinaAz.Application.Features.Queries.Items.GardenHouses;

public class GardenHousesQueryRequest : IRequest<GardenHousesQueryResponse>
{
    public int Page { get; set; }
    public bool More { get; set; }
    public bool IsRent { get; set; }
}