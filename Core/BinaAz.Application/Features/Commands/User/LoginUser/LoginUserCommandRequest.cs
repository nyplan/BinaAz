using MediatR;

namespace BinaAz.Application.Features.Commands.User.LoginUser;

public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
{
    public string EmailOrPhone { get; set; }
    public string Password { get; set; }
}