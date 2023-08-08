using BinaAz.Application.DTOs.User;
using MediatR;

namespace BinaAz.Application.Features.Commands.User.RegisterWithPhoneAgency;

public class RegisterWithPhoneAgencyCommandRequest : IRequest<RegisterWithPhoneAgencyCommandResponse>
{
    public RegisterAsAgencyPhoneDto Dto { get; set; } = null!;
}