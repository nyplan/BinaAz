using BinaAz.Application.Abstractions.Services;
using BinaAz.Application.DTOs.User;
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
        CreateUserResponse response = await _userService.CreateAsync(new()
        {
            Phone = request.Dto.Phone,
            Password = request.Dto.Password,
            PasswordConfirm = request.Dto.PasswordConfirm
        });
        return new()
        {
            Message = response.Message,
            Succeeded = response.Succeeded
        };
    }
}