using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BinaAz.Application.Abstractions.Token;
using BinaAz.Application.DTOs.Tokens;
using BinaAz.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BinaAz.Infrastructure.Services.Token;

public class TokenHandler : ITokenHandler
{
    private readonly IConfiguration _configuration;

    public TokenHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public JsonWebToken CreateAccessToken(User user)
    {
        JsonWebToken token = new();

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]!));

        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        token.Expiration = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Token:AccessTokenLifetime"]!));

        JwtSecurityToken securityToken = new(
            audience: _configuration["Token:Audience"],
            issuer: _configuration["Token:Issuer"],
            expires: token.Expiration,
            notBefore: DateTime.UtcNow,
            signingCredentials: signingCredentials,
            claims: new List<Claim>()
            {
                new(ClaimTypes.Sid, user.Id.ToString()), 
                new(ClaimTypes.Name, user.Phone ?? user.Email!)
            });

        JwtSecurityTokenHandler tokenHandler = new();

        token.AccessToken = tokenHandler.WriteToken(securityToken);
        token.RefreshToken = CreateRefreshToken();
        return token;
    }
    public string CreateRefreshToken()
    {
        byte[] number = new byte[32];
        using RandomNumberGenerator random = RandomNumberGenerator.Create();
        random.GetBytes(number);
        return Convert.ToBase64String(number);
    }
}