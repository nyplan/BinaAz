using BinaAz.Application.DTOs.User;
using MediatR;

namespace BinaAz.Application.Features.Commands.User.RegisterWithEmailResident;

public class RegisterWithEmailResidentCommandRequest : IRequest<RegisterWithEmailResidentCommandResponse>
{
    public RegisterAsResidentialComplexEmailDto Dto { get; set; }
}