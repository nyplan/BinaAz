using BinaAz.Application.DTOs.User;
using MediatR;

namespace BinaAz.Application.Features.Commands.User.RegisterWithPhoneResident;

public class RegisterWithPhoneResidentCommandRequest : IRequest<RegisterWithPhoneResidentCommandResponse>
{
    public RegisterAsResidentialComplexPhoneDto Dto { get; set; } = null!;
}