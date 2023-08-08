using BinaAz.Application.DTOs.User;
using MediatR;

namespace BinaAz.Application.Features.Commands.User.RegisterWithEmailAgency;

public class RegisterWithEmailAgencyCommandRequest : IRequest<RegisterWithEmailAgencyCommandResponse>
{
    public RegisterAsAgencyEmailDto Dto { get; set; } = null!;
}