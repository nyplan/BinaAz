using BinaAz.Application.Abstractions.Services;
using MediatR;

namespace BinaAz.Application.Features.Commands.User.RegisterWithPhoneResident;

public class RegisterWithPhoneResidentCommandHandler : IRequestHandler<RegisterWithPhoneResidentCommandRequest, RegisterWithPhoneResidentCommandResponse>
{
    private readonly IUserService _userService;

    public RegisterWithPhoneResidentCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<RegisterWithPhoneResidentCommandResponse> Handle(RegisterWithPhoneResidentCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.CreateResidentialComplexAsync(new()
        {
            Phone = request.Dto.Phone,
            Password = request.Dto.Password,
            PasswordConfirm = request.Dto.PasswordConfirm,
            CompanyName = request.Dto.CompanyName,
            RelevantPerson = request.Dto.RelevantPerson,
            Address = request.Dto.Address,
            HandOverYear = request.Dto.HandOverYear
        });
        return new() { Success = response };
    }
}