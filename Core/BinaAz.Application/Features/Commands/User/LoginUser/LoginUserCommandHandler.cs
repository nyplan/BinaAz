using BinaAz.Application.Abstractions.Services;
using MediatR;

namespace BinaAz.Application.Features.Commands.User.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    private readonly IAuthService _authService;

    public LoginUserCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        var token = await _authService.LoginAsync(request.EmailOrPhone, request.Password);
        return new() { Token = token };
    }
}