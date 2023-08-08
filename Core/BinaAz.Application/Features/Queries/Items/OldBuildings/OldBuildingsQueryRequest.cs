using MediatR;

namespace BinaAz.Application.Features.Queries.Items.OldBuildings;

public class OldBuildingsQueryRequest : IRequest<OldBuildingsQueryResponse>
{
    public int Page { get; set; }
    public bool More { get; set; }
    public bool IsRent { get; set; }
}