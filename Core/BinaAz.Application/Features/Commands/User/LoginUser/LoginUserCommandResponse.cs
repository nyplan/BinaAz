using BinaAz.Application.DTOs.Tokens;

namespace BinaAz.Application.Features.Commands.User.LoginUser;

public class LoginUserCommandResponse
{
    public JsonWebToken Token { get; set; }
}