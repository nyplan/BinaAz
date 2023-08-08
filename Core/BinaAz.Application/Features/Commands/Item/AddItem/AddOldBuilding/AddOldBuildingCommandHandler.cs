using BinaAz.Application.Abstractions.Services;
using BinaAz.Application.Abstractions.Storages;
using BinaAz.Application.Extensions;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities;
using BinaAz.Domain.Entities.TPH;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BinaAz.Application.Features.Commands.Item.AddItem.AddOldBuilding;

public class AddOldBuildingCommandHandler : IRequestHandler<AddOldBuildingCommandRequest, AddOldBuildingCommandResponse>
{
    private readonly IItemService _itemService;
    private readonly ILocalStorageService _localStorageService;
    private readonly IRepository<Image> _imageRepository;
    private readonly IRepository<Domain.Entities.TPH.Base.Item> _itemRepository;
    private readonly IHttpContextAccessor _contextAccessor;

    public AddOldBuildingCommandHandler(IItemService itemService, ILocalStorageService localStorageService, IRepository<Image> imageRepository, IRepository<Domain.Entities.TPH.Base.Item> itemRepository, IHttpContextAccessor contextAccessor)
    {
        _itemService = itemService;
        _localStorageService = localStorageService;
        _imageRepository = imageRepository;
        _itemRepository = itemRepository;
        _contextAccessor = contextAccessor;
    }

    public async Task<AddOldBuildingCommandResponse> Handle(AddOldBuildingCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _itemService.MapToItem<OldBuilding>(request.Dto);
        item.UserId = _contextAccessor.HttpContext!.User.GetId();
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