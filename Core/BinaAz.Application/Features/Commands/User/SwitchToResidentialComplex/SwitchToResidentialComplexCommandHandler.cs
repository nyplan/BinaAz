using BinaAz.Application.Exceptions;
using BinaAz.Application.Extensions;
using BinaAz.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BinaAz.Application.Features.Commands.User.SwitchToResidentialComplex;

public class SwitchToResidentialComplexCommandHandler : IRequestHandler<SwitchToResidentialComplexCommandRequest, string>
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IRepository<Domain.Entities.User> _userRepository;
    
    public SwitchToResidentialComplexCommandHandler(IHttpContextAccessor contextAccessor, IRepository<Domain.Entities.User> userRepository)
    {
        _contextAccessor = contextAccessor;
        _userRepository = userRepository;
    }

    public async Task<string> Handle(SwitchToResidentialComplexCommandRequest request, CancellationToken cancellationToken)
    {
        if (_contextAccessor.HttpContext is null)
            throw new AuthenticationException();
        var user = await _userRepository.GetSingleAsync(x => x.Id == _contextAccessor.HttpContext.User.GetId());

        if (user is null)
            throw new UserNotFoundException();

        user.IsAgency = null;
        
        user.RelevantPerson = request.RelevantPerson;
        user.CompanyName = request.CompanyName;
        user.Address = request.Address;
        user.HandOverYear = request.HandOverYear;
        user.IsResidentialComplex = true;

        await _userRepository.SaveAsync();
        return "Profile successfully switched to Agency profile";
    }
}