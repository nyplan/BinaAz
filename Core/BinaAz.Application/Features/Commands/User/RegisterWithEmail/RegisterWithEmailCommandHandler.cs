using BinaAz.Application.Abstractions.Services;
using MediatR;

namespace BinaAz.Application.Features.Commands.User.RegisterWithEmail;
 
public class RegisterWithEmailCommandHandler : IRequestHandler<RegisterWithEmailCommandRequest, RegisterWithEmailCommandResponse>
{
    private readonly IUserService _userService;

    public RegisterWithEmailCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<RegisterWithEmailCommandResponse> Handle(RegisterWithEmailCommandRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _userService.CreateUserAsync(new()
        {
            Email = request.Dto.Email,
            Password = request.Dto.Password,
            PasswordConfirm = request.Dto.PasswordConfirm
        });
        return new();

    }
}