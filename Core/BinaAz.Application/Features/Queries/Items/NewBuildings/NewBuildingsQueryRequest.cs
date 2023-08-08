using MediatR;

namespace BinaAz.Application.Features.Queries.Items.NewBuildings;

public class NewBuildingsQueryRequest : IRequest<NewBuildingsQueryResponse>
{
    public int Page { get; set; }
    public bool More { get; set; }
    public bool IsRent { get; set; }
}