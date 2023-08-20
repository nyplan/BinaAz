using BinaAz.Application.Abstractions.Services;
using MediatR;

namespace BinaAz.Application.Features.Commands.User.RegisterWithPhone;

public class RegisterWithPhoneCommandHandler : IRequestHandler<RegisterWithPhoneCommandRequest, RegisterWithPhoneCommandResponse>
{
    private readonly IUserService _userService;

    public RegisterWithPhoneCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<RegisterWithPhoneCommandResponse> Handle(RegisterWithPhoneCommandRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _userService.CreateUserAsync(new()
        {
            Phone = request.Dto.Phone,
            Password = request.Dto.Password,
            PasswordConfirm = request.Dto.PasswordConfirm
        });
        return new() { Success = response };
    }
}