using BinaAz.Application.DTOs.Tokens;

namespace BinaAz.Application.Abstractions.Services;

public interface IAuthService
{
    Task<JsonWebToken> LoginAsync(string phoneOrEmail, string password, int lifetime);
    Task<JsonWebToken> RefreshLoginAsync(string refreshToken);
}