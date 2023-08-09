using BinaAz.Application.Exceptions;
using BinaAz.Application.Extensions;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BinaAz.Application.Features.Commands.Subscriptions.Premium;

public class MakeItemPremiumCommandHandler : IRequestHandler<MakeItemPremiumCommandRequest, string>
{
    private readonly IRepository<Domain.Entities.User> _userRepository;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IRepository<Domain.Entities.TPH.Base.Item> _itemRepository;

    public MakeItemPremiumCommandHandler(IRepository<Domain.Entities.User> userRepository, IHttpContextAccessor contextAccessor, IRepository<Domain.Entities.TPH.Base.Item> itemRepository)
    {
        _userRepository = userRepository;
        _contextAccessor = contextAccessor;
        _itemRepository = itemRepository;
    }

    public async Task<string> Handle(MakeItemPremiumCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetSingleAsync(x => _contextAccessor.HttpContext.User.GetId() == x.Id);
        if (user is null)
            throw new NotFoundUserException();
        var item = await _itemRepository.GetSingleAsync(x => x.ItemNumber == request.ItemNumber);
        if (item is null || user.Id != item.UserId)
            throw new ItemNotFoundException();

        int price = request.Price switch
        {
            PremiumType.Day1 => 5,
            PremiumType.Day5 => 20,
            PremiumType.Day15 => 40,
            PremiumType.Day30 => 60,
            _ => throw new Exception("Unsupported Premium type")
        };

        if (user.Balance < price)
            throw new Exception("Insufficient amount, please increase your balance.");
        user.Balance -= price;
        item.IsPremium = true;
        int days = request.Price switch
        {
            PremiumType.Day1 => 1,
            PremiumType.Day5 => 5,
            PremiumType.Day15 => 15,
            PremiumType.Day30 => 30,
            _ => throw new Exception("Unsupported Premium type")
        };
        item.PremiumEnds = DateTime.UtcNow.AddDays(days);
        await _itemRepository.SaveAsync();

        return $"Operation successfully completed! Premium ends {item.PremiumEnds}";
    }
}