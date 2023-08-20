using BinaAz.Application.Abstractions.Services;
using BinaAz.Application.Abstractions.Storages;
using BinaAz.Application.Exceptions;
using BinaAz.Application.Extensions;
using BinaAz.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Object = BinaAz.Domain.Entities.TPH.Object;

namespace BinaAz.Application.Features.Commands.Item.UpdateItem.UpdateObject;

public class UpdateObjectCommandHandler : IRequestHandler<UpdateObjectCommandRequest, UpdateObjectCommandResponse>
{
    private readonly IItemService _itemService;
    private readonly ILocalStorageService _localStorageService;
    private readonly IRepository<Domain.Entities.TPH.Base.Item> _itemRepository;
    private readonly IHttpContextAccessor _contextAccessor;

    public UpdateObjectCommandHandler(IItemService itemService, ILocalStorageService localStorageService, IRepository<Domain.Entities.TPH.Base.Item> itemRepository, IHttpContextAccessor contextAccessor)
    {
        _itemService = itemService;
        _localStorageService = localStorageService;
        _itemRepository = itemRepository;
        _contextAccessor = contextAccessor;
    }

    public async Task<UpdateObjectCommandResponse> Handle(UpdateObjectCommandRequest request, CancellationToken cancellationToken)
    {
        if (_contextAccessor.HttpContext is null)
            throw new AuthenticationException();

        var item = await _itemRepository.GetSingleAsync(x => x.ItemNumber == request.ItemNumber);
        
        if (item is null || item.UserId != _contextAccessor.HttpContext.User.GetId())
            throw new ItemNotFoundException();

        foreach (var url in item.ImageUrls)
            await _localStorageService.DeleteAsync(url);

        var newItem = await _itemService.UpdateItem<Object>(request.Dto, request.ItemNumber);
        newItem.Id = item.Id;
        
        var images =  await _localStorageService.UploadAsync($"item-images\\{item.ItemNumber}", request.Dto.Images);
        
        foreach (var image in images)
            newItem.ImageUrls.Add(image);
        
        _itemRepository.Update(newItem);
        await _itemRepository.SaveAsync();
        return new();
    }
}