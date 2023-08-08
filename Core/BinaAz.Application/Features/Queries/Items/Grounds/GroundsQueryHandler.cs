using BinaAz.Application.Abstractions.Services;
using BinaAz.Domain.Entities.TPH;
using MediatR;

namespace BinaAz.Application.Features.Queries.Items.Grounds;

public class GroundsQueryHandler : IRequestHandler<GroundsQueryRequest, GroundsQueryResponse>
{
    private readonly IItemService _itemService;

    public GroundsQueryHandler(IItemService itemService)
    {
        _itemService = itemService;
    }

    public async Task<GroundsQueryResponse> Handle(GroundsQueryRequest request, CancellationToken cancellationToken)
    {
        var garages = await _itemService.MapToItemWithPaging<Ground>(request.Page, request.More, request.IsRent);
        return new() { Items = garages };
    }
}