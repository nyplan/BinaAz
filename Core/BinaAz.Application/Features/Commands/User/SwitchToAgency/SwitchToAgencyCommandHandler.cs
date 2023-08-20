using BinaAz.Application.Exceptions;
using BinaAz.Application.Extensions;
using BinaAz.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BinaAz.Application.Features.Commands.User.SwitchToAgency;

public class SwitchToAgencyCommandHandler : IRequestHandler<SwitchToAgencyCommandRequest, string>
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IRepository<Domain.Entities.User> _userRepository;

    public SwitchToAgencyCommandHandler(IHttpContextAccessor contextAccessor, IRepository<Domain.Entities.User> userRepository)
    {
        _contextAccessor = contextAccessor;
        _userRepository = userRepository;
    }

    public async Task<string> Handle(SwitchToAgencyCommandRequest request, CancellationToken cancellationToken)
    {
        if (_contextAccessor.HttpContext is null)
            throw new AuthenticationException();
        var user = await _userRepository.GetSingleAsync(x => x.Id == _contextAccessor.HttpContext.User.GetId());

        if (user is null)
            throw new UserNotFoundException();

        user.IsResidentialComplex = null;
        user.Address = null;
        user.HandOverYear = null;
        
        user.RelevantPerson = request.RelevantPerson;
        user.CompanyName = request.CompanyName;
        user.IsAgency = true;

        await _userRepository.SaveAsync();
        return "Profile successfully switched to Agency profile";
    }
}