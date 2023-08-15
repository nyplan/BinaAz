using BinaAz.Application.DTOs.User;
using BinaAz.Domain.Entities;

namespace BinaAz.Application.Abstractions.Services;

public interface IUserService
{
    Task<bool> CreateUserAsync(CreateUser model);
    Task<bool> UpdateUserAsync(UpdateUser model);
    Task UpdateRefreshToken(string refreshToken, User user, DateTime accessTokenExpires, int refreshTokenLifetime);
}