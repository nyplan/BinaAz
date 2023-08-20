using BinaAz.Application.Exceptions;
using BinaAz.Application.Extensions;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BinaAz.Application.Features.Commands.Subscriptions.VIP;

public class MakeItemVipCommandHandler : IRequestHandler<MakeItemVipCommandRequest, string>
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IRepository<Domain.Entities.TPH.Base.Item> _itemRepository;
    private readonly IRepository<Domain.Entities.User> _userRepository;

    public MakeItemVipCommandHandler(IHttpContextAccessor contextAccessor,
        IRepository<Domain.Entities.TPH.Base.Item> itemRepository, IRepository<Domain.Entities.User> userRepository)
    {
        _contextAccessor = contextAccessor;
        _itemRepository = itemRepository;
        _userRepository = userRepository;
    }

    public async Task<string> Handle(MakeItemVipCommandRequest request,
        CancellationToken cancellationToken)
    {
        if (_contextAccessor.HttpContext is null)
            throw new AuthenticationException();
        var user = await _userRepository.GetSingleAsync(x => _contextAccessor.HttpContext.User.GetId() == x.Id);
        if (user is null)
            throw new UserNotFoundException();
        var item = await _itemRepository.GetSingleAsync(x => x.ItemNumber == request.ItemNumber);
        if (item is null || user.Id != item.UserId)
            throw new ItemNotFoundException();

        if (item.IsPremium is true)
            throw new Exception("You already have Premium Subscription");
        
        int price = request.Price switch
        {
            VipType.Day5 => 10,
            VipType.Day15 => 20,
            VipType.Day30 => 30,
            _ => throw new Exception("Unsupported VIP type")
        };

        if (user.Balance < price)
            throw new Exception("Insufficient balance");
        user.Balance -= price;
        item.IsVip = true;
        int days = request.Price switch
        {
            VipType.Day5 => 5,
            VipType.Day15 => 15,
            VipType.Day30 => 30,
            _ => throw new Exception("Unsupported VIP type")
        };
        item.VipEnds = DateTime.UtcNow.AddDays(days);
        await _itemRepository.SaveAsync();

        return $"Operation successfully completed! VIP ends {item.VipEnds}";
    }
}