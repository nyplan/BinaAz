using BinaAz.Application.Exceptions;
using BinaAz.Application.Extensions;
using BinaAz.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BinaAz.Application.Features.Commands.Item.DeleteItem;

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommandRequest, string>
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IRepository<Domain.Entities.TPH.Base.Item> _itemRepository;

    public DeleteItemCommandHandler(IHttpContextAccessor contextAccessor, IRepository<Domain.Entities.TPH.Base.Item> itemRepository)
    {
        _contextAccessor = contextAccessor;
        _itemRepository = itemRepository;
    }

    public async Task<string> Handle(DeleteItemCommandRequest request, CancellationToken cancellationToken)
    {
        if (_contextAccessor.HttpContext is null)
            throw new AuthenticationException();

        var item = await _itemRepository.GetSingleAsync(x => x.ItemNumber == request.ItemNumber);
        if (item is null)
            throw new ItemNotFoundException();

        if (item.UserId != _contextAccessor.HttpContext.User.GetId())
            throw new Exception("You do not access to remove this item");

        _itemRepository.Remove(item);
        await _itemRepository.SaveAsync();
        return "Item deleted successfully";
    }
}