using BinaAz.Application.Exceptions;
using BinaAz.Application.Extensions;
using BinaAz.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BinaAz.Application.Features.Commands.LikedItems.DislikeAnItem;

public class DislikeAnItemCommandHandler : IRequestHandler<DislikeAnItemCommandRequest, bool>
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IRepository<Domain.Entities.User> _userRepository;
    private readonly IRepository<Domain.Entities.TPH.Base.Item> _itemRepository;

    public DislikeAnItemCommandHandler(IHttpContextAccessor contextAccessor, IRepository<Domain.Entities.User> userRepository, IRepository<Domain.Entities.TPH.Base.Item> itemRepository)
    {
        _contextAccessor = contextAccessor;
        _userRepository = userRepository;
        _itemRepository = itemRepository;
    }

    public async Task<bool> Handle(DislikeAnItemCommandRequest request, CancellationToken cancellationToken)
    {
        if (_contextAccessor.HttpContext is null)
            throw new AuthenticationException();
        var user = await _userRepository.GetSingleAsync(x => x.Id == _contextAccessor.HttpContext.User.GetId());
        if (user is null)
            throw new UserNotFoundException();
        var item = await _itemRepository.Table
            .Include(x => x.LikedUsers)
            .FirstOrDefaultAsync(x => x.ItemNumber == request.ItemNumber, cancellationToken);
        if (item is null)
            throw new ItemNotFoundException();
        
        if (!item.LikedUsers.Contains(user))
            return false;

        item.LikedUsers.Remove(user);
        await _itemRepository.SaveAsync();
        return true;
    }
}