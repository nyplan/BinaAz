using BinaAz.Application.Abstractions.Services;
using MediatR;
using Object = BinaAz.Domain.Entities.TPH.Object;

namespace BinaAz.Application.Features.Queries.Items.Objects;

public class ObjectsQueryHandler : IRequestHandler<ObjectsQueryRequest, ObjectsQueryResponse>
{
    private readonly IItemService _itemService;

    public ObjectsQueryHandler(IItemService itemService)
    {
        _itemService = itemService;
    }

    public async Task<ObjectsQueryResponse> Handle(ObjectsQueryRequest request, CancellationToken cancellationToken)
    {
        var objects = await _itemService.MapToItemWithPaging<Object>(request.Page, request.More, request.IsRent);
        return new() { Items = objects };
    }
}