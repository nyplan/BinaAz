using BinaAz.Application.DTOs.Tokens;
using BinaAz.Domain.Entities;

namespace BinaAz.Application.Abstractions.Token;

public interface ITokenHandler
{
    JsonWebToken CreateAccessToken(User user);
    string CreateRefreshToken();
}