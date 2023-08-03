using BinaAz.Application.DTOs.Tokens;

namespace BinaAz.Application.Features.Commands.User.RefreshLogin;

public class RefreshLoginCommandResponse
{
    public JsonWebToken Token { get; set; }
}