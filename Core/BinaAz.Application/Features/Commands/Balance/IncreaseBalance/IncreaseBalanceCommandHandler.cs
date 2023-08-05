using BinaAz.Application.Exceptions;
using BinaAz.Application.Extensions;
using BinaAz.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BinaAz.Application.Features.Commands.Balance.IncreaseBalance;

public class IncreaseBalanceCommandHandler : IRequestHandler<IncreaseBalanceCommandRequest, IncreaseBalanceCommandResponse>
{
    private readonly IRepository<Domain.Entities.User> _userRepository;
    private readonly IHttpContextAccessor _contextAccessor;

    public IncreaseBalanceCommandHandler(IRepository<Domain.Entities.User> userRepository, IHttpContextAccessor contextAccessor)
    {
        _userRepository = userRepository;
        _contextAccessor = contextAccessor;
    }

    public async Task<IncreaseBalanceCommandResponse> Handle(IncreaseBalanceCommandRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetSingleAsync(x => x.Id == _contextAccessor.HttpContext.User.GetId());
        if (user is null)
            throw new NotFoundUserException();
        user.Balance += request.Amount;
        await _userRepository.SaveAsync();
        return new() { Balance = user.Balance, Message = "Balance successfully increased!" };
    }
}