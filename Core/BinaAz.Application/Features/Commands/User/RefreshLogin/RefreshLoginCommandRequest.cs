using MediatR;

namespace BinaAz.Application.Features.Commands.User.RefreshLogin;

public class RefreshLoginCommandRequest : IRequest<RefreshLoginCommandResponse>
{
    public string RefreshToken { get; set; }
}