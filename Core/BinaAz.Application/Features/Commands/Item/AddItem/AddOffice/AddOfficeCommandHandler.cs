using BinaAz.Application.Abstractions.Services;
using BinaAz.Application.Abstractions.Storages;
using BinaAz.Application.Exceptions;
using BinaAz.Application.Extensions;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities;
using BinaAz.Domain.Entities.TPH;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BinaAz.Application.Features.Commands.Item.AddItem.AddOffice;

public class AddOfficeCommandHandler : IRequestHandler<AddOfficeCommandRequest, AddOfficeCommandResponse>
{
    private readonly IItemService _itemService;
    private readonly ILocalStorageService _localStorageService;
    private readonly IRepository<Domain.Entities.TPH.Base.Item> _itemRepository;
    private readonly IHttpContextAccessor _contextAccessor;

    public AddOfficeCommandHandler(IItemService itemService, ILocalStorageService localStorageService, IRepository<Domain.Entities.TPH.Base.Item> itemRepository, IHttpContextAccessor contextAccessor)
    {
        _itemService = itemService;
        _localStorageService = localStorageService;
        _itemRepository = itemRepository;
        _contextAccessor = contextAccessor;
    }

    public async Task<AddOfficeCommandResponse> Handle(AddOfficeCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await _itemService.MapToItem<Office>(request.Dto);
        if (_contextAccessor.HttpContext?.User is null)
            throw new AuthenticationException();
        try
        {
            item.UserId = _contextAccessor.HttpContext.User.GetId();
        }
        catch (Exception e)
        {
            return new() { Message = e.Message };
        }
        var images =  await _localStorageService.UploadAsync($"item-images\\{item.ItemNumber}", request.Dto.Images);
        foreach (var image in images)
            item.ImageUrls.Add(image);
        await _itemRepository.AddAsync(item);
        await _itemRepository.SaveAsync();
        return new();
    }
}