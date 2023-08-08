using BinaAz.Application.Abstractions.Services;
using MediatR;

namespace BinaAz.Application.Features.Commands.User.RegisterWithPhoneAgency;

public class RegisterWithPhoneAgencyCommandHandler : IRequestHandler<RegisterWithPhoneAgencyCommandRequest, RegisterWithPhoneAgencyCommandResponse>
{
    private readonly IUserService _userService;

    public RegisterWithPhoneAgencyCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<RegisterWithPhoneAgencyCommandResponse> Handle(RegisterWithPhoneAgencyCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.CreateAgencyAsync(new()
        {
            Phone = request.Dto.Phone,
            CompanyName = request.Dto.CompanyName,
            RelevantPerson = request.Dto.RelevantPerson,
            Password = request.Dto.Password,
            PasswordConfirm = request.Dto.PasswordConfirm
        });
        return new() { Success = response };
    }
}