using BinaAz.Application.Abstractions.Services;
using BinaAz.Application.Abstractions.Storages;
using BinaAz.Application.Extensions;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Object = BinaAz.Domain.Entities.TPH.Object;

namespace BinaAz.Application.Features.Commands.Item.AddItem.AddObject;

public class AddObjectCommandHandler : IRequestHandler<AddObjectCommandRequest, AddObjectCommandResponse>
{
    private readonly IItemService _itemService;
    private readonly ILocalStorageService _localStorageService;
    private readonly IRepository<Image> _imageRepository;
    private readonly IRepository<Domain.Entities.TPH.Base.Item> _itemRepository;
    private readonly IHttpContextAccessor _contextAccessor;

    public AddObjectCommandHandler(IItemService itemService, ILocalStorageService localStorageService, IRepository<Image> imageRepository, IRepository<Domain.Entities.TPH.Base.Item> itemRepository, IHttpContextAccessor contextAccessor)
    {
        _itemService = itemService;
        _localStorageService = localStorageService;
        _imageRepository = imageRepository;
        _itemRepository = itemRepository;
        _contextAccessor = contextAccessor;
    }

    public async Task<AddObjectCommandResponse> Handle(AddObjectCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _itemService.MapToItem<Object>(request.Dto);
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