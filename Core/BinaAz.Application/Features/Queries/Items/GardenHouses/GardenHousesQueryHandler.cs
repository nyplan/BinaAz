using BinaAz.Application.Abstractions.Services;
using BinaAz.Domain.Entities.TPH;
using MediatR;

namespace BinaAz.Application.Features.Queries.Items.GardenHouses;

public class GardenHousesQueryHandler : IRequestHandler<GardenHousesQueryRequest, GardenHousesQueryResponse>
{
    private readonly IItemService _itemService;

    public GardenHousesQueryHandler(IItemService itemService)
    {
        _itemService = itemService;
    }

    public async Task<GardenHousesQueryResponse> Handle(GardenHousesQueryRequest request, CancellationToken cancellationToken)
    {
        var gardenHouses = await _itemService.MapToItemWithPaging<GardenHouse>(request.Page, request.More, request.IsRent);
        return new() { Items = gardenHouses };
    }
}