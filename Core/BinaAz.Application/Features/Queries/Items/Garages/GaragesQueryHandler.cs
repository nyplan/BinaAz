using BinaAz.Application.Abstractions.Services;
using BinaAz.Domain.Entities.TPH;
using MediatR;

namespace BinaAz.Application.Features.Queries.Items.Garages;

public class GaragesQueryHandler : IRequestHandler<GaragesQueryRequest, GaragesQueryResponse>
{
    private readonly IItemService _itemService;

    public GaragesQueryHandler(IItemService itemService)
    {
        _itemService = itemService;
    }

    public async Task<GaragesQueryResponse> Handle(GaragesQueryRequest request, CancellationToken cancellationToken)
    {
        var garages = await _itemService.MapToItemWithPaging<Garage>(request.Page, request.More, request.IsRent);
        return new() { Items = garages };
    }
}