using BinaAz.Application.Abstractions.Services;
using BinaAz.Application.Repositories;
using MediatR;

namespace BinaAz.Application.Features.Commands.Item.AddNewBuildingRentItem;

public class AddNewBuildingRentItemCommandHandler : IRequestHandler<AddNewBuildingRentItemCommandRequest, AddNewBuildingRentItemCommandResponse>
{
    private readonly IRepository<Domain.Entities.TPH.Base.Item> _itemRepository;
    private readonly IItemService _itemService;

    public AddNewBuildingRentItemCommandHandler(IRepository<Domain.Entities.TPH.Base.Item> itemRepository, IItemService itemService)
    {
        _itemRepository = itemRepository;
        _itemService = itemService;
    }

    public async Task<AddNewBuildingRentItemCommandResponse> Handle(AddNewBuildingRentItemCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _itemService.MapToItem<Domain.Entities.TPH.Base.Item>(request.Dto);
        await _itemRepository.AddAsync(item);
        await _itemRepository.SaveAsync();
        return new();
    }
}