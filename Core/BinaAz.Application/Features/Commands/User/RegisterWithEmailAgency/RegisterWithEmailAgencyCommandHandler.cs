using BinaAz.Application.Abstractions.Services;
using MediatR;

namespace BinaAz.Application.Features.Commands.User.RegisterWithEmailAgency;

public class RegisterWithEmailAgencyCommandHandler : IRequestHandler<RegisterWithEmailAgencyCommandRequest, RegisterWithEmailAgencyCommandResponse>
{
    private readonly IUserService _userService;

    public RegisterWithEmailAgencyCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<RegisterWithEmailAgencyCommandResponse> Handle(RegisterWithEmailAgencyCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.CreateAgencyAsync(new()
        {
            Email = request.Dto.Email,
            Password = request.Dto.Password,
            PasswordConfirm = request.Dto.PasswordConfirm,
            CompanyName = request.Dto.CompanyName,
            RelevantPerson = request.Dto.RelevantPerson
        });
        return new() { Success = response };
    }
}