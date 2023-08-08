using BinaAz.Application.Abstractions.Services;
using BinaAz.Domain.Entities.TPH;
using MediatR;

namespace BinaAz.Application.Features.Queries.Items.NewBuildings;

public class NewBuildingsQueryHandler : IRequestHandler<NewBuildingsQueryRequest, NewBuildingsQueryResponse>
{
    private readonly IItemService _itemService;

    public NewBuildingsQueryHandler(IItemService itemService)
    {
        _itemService = itemService;
    }

    public async Task<NewBuildingsQueryResponse> Handle(NewBuildingsQueryRequest request, CancellationToken cancellationToken)
    {
        var newBuildings =
            await _itemService.MapToItemWithPaging<NewBuilding>(request.Page, request.More, request.IsRent);
        return new() { Items = newBuildings };
    }
}