using BinaAz.Application.Abstractions.Services;
using MediatR;

namespace BinaAz.Application.Features.Commands.User.RegisterWithEmailResident;

public class RegisterWithEmailResidentCommandHandler : IRequestHandler<RegisterWithEmailResidentCommandRequest, RegisterWithEmailResidentCommandResponse>
{
    private readonly IUserService _userService;

    public RegisterWithEmailResidentCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<RegisterWithEmailResidentCommandResponse> Handle(RegisterWithEmailResidentCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.CreateResidentialComplexAsync(new()
        {
            Email = request.Dto.Email,
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