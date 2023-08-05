using BinaAz.Application.Abstractions.Services;
using BinaAz.Application.Abstractions.Storages;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities;
using BinaAz.Domain.Entities.TPH;
using MediatR;

namespace BinaAz.Application.Features.Commands.Item.AddGarageRentItem;

public class AddGarageCommandHandler : IRequestHandler<AddGarageCommandRequest, AddGarageCommandResponse>
{
    private readonly IItemService _itemService;
    private readonly ILocalStorageService _localStorageService;
    private readonly IRepository<Image> _imageRepository;
    private readonly IRepository<Domain.Entities.TPH.Base.Item> _itemRepository;

    public AddGarageCommandHandler(IItemService itemService, ILocalStorageService localStorageService, IRepository<Image> imageRepository, IRepository<Domain.Entities.TPH.Base.Item> itemRepository)
    {
        _itemService = itemService;
        _localStorageService = localStorageService;
        _imageRepository = imageRepository;
        _itemRepository = itemRepository;
    }

    public async Task<AddGarageCommandResponse> Handle(AddGarageCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _itemService.MapToItem<Garage>(request.Dto);
        var images =  await _localStorageService.UploadAsync($"item-images/{item.ItemNumber}", request.Dto.Images);
        await _itemRepository.AddAsync(item);
        foreach (var image in images)
        {
            item.Images.Add(new()
            {
                Path = image.path,
                FileName = image.fileName,
                ItemNumber = item.ItemNumber
            });
        }
        await _imageRepository.AddRangeAsync(item.Images);
        await _imageRepository.SaveAsync();

        return new();
    }
}