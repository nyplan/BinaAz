using BinaAz.Application.DTOs.User;
using MediatR;

namespace BinaAz.Application.Features.Commands.User.RegisterWithEmail;

public class RegisterWithEmailCommandRequest : IRequest<RegisterWithEmailCommandResponse>
{
    public RegisterWithEmailDto Dto { get; set; } = null!;
}