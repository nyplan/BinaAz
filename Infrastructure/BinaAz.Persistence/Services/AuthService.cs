using BinaAz.Application.Abstractions.Services;
using BinaAz.Application.Abstractions.Token;
using BinaAz.Application.DTOs.Tokens;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities;
using BinaAz.Infrastructure.Operations;
using Microsoft.Extensions.Configuration;

namespace BinaAz.Persistence.Services;

public class AuthService : IAuthService
{
    private readonly IRepository<User> _userRepository;
    private readonly ITokenHandler _tokenHandler;
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public AuthService(IRepository<User> userRepository, ITokenHandler tokenHandler, IUserService userService, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _tokenHandler = tokenHandler;
        _userService = userService;
        _configuration = configuration;
    }

    public async Task<JsonWebToken> LoginAsync(string phoneOrEmail, string password, int lifetime)
    {
        User user =
            await _userRepository.GetSingleAsync(x => x.Email == phoneOrEmail || x.Phone == phoneOrEmail) ??
            throw new Exception("User does not exist");

        bool isPasswordCorrect = PasswordOperation.VerifyPassword(password, user.Salt, user.HashedPassword);

        if (!isPasswordCorrect)
            throw new Exception("Password is incorrect");
        JsonWebToken token = _tokenHandler.CreateAccessToken(user);
        await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, int.Parse(_configuration["Token:RefreshTokenLifetime"]!));
        return token;
    }

    public async Task<JsonWebToken> RefreshLoginAsync(string refreshToken)
    {
        User? user = await _userRepository.GetSingleAsync(u => u.RefreshToken == refreshToken);

        if (user == null || user?.RefreshTokenExpires < DateTime.UtcNow)
            throw new Exception("User Not Found");

        JsonWebToken token = _tokenHandler.CreateAccessToken(user!);
        await _userService.UpdateRefreshToken(token.RefreshToken, user!, token.Expiration,
            int.Parse(_configuration["Token:RefreshTokenLifetime"]!));
        return token;
    }
}