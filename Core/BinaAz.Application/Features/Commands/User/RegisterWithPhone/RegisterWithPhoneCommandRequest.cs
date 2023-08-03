using BinaAz.Application.DTOs.User;
using MediatR;

namespace BinaAz.Application.Features.Commands.User.RegisterWithPhone;

public class RegisterWithPhoneCommandRequest : IRequest<RegisterWithPhoneCommandResponse>
{
    public RegisterWithPhoneDto Dto { get; set; } = null!;
}