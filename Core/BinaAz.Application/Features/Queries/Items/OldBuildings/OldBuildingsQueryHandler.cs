using BinaAz.Application.Abstractions.Services;
using BinaAz.Domain.Entities.TPH;
using MediatR;

namespace BinaAz.Application.Features.Queries.Items.OldBuildings;

public class OldBuildingsQueryHandler : IRequestHandler<OldBuildingsQueryRequest, OldBuildingsQueryResponse>
{
    private readonly IItemService _itemService;

    public OldBuildingsQueryHandler(IItemService itemService)
    {
        _itemService = itemService;
    }

    public async Task<OldBuildingsQueryResponse> Handle(OldBuildingsQueryRequest request, CancellationToken cancellationToken)
    {
        var oldBuildings = await _itemService.MapToItemWithPaging<OldBuilding>(request.Page, request.More, request.IsRent);
        return new() { Items = oldBuildings };
    }
}