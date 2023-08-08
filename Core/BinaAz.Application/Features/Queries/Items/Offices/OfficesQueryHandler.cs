using BinaAz.Application.Abstractions.Services;
using BinaAz.Domain.Entities.TPH;
using MediatR;

namespace BinaAz.Application.Features.Queries.Items.Offices;

public class OfficesQueryHandler : IRequestHandler<OfficesQueryRequest, OfficesQueryResponse>
{
    private readonly IItemService _itemService;

    public OfficesQueryHandler(IItemService itemService)
    {
        _itemService = itemService;
    }

    public async Task<OfficesQueryResponse> Handle(OfficesQueryRequest request, CancellationToken cancellationToken)
    {
        var offices = await _itemService.MapToItemWithPaging<Office>(request.Page, request.More, request.IsRent);
        return new() { Items = offices };
    }
}