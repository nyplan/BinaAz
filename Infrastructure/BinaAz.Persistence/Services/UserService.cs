using BinaAz.Application.Abstractions.Services;
using BinaAz.Application.DTOs.User;
using BinaAz.Application.Exceptions;
using BinaAz.Application.Extensions;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities;
using BinaAz.Infrastructure.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BinaAz.Persistence.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;
    private readonly IHttpContextAccessor _contextAccessor;


    public UserService(IRepository<User> userRepository, IHttpContextAccessor contextAccessor)
    {
        _userRepository = userRepository;
        _contextAccessor = contextAccessor;
    }

    public async Task<bool> CreateUserAsync(CreateUser model)
    {
        if (model.Password != model.PasswordConfirm)
            throw new Exception("Passwords does not match");

        var hashedPassword = PasswordOperation.CalculateSha256Hash(model.Password);
        
        if (model.Email is not null)
        {
            if (_userRepository.Table.Any(c => c.Email == model.Email))
                throw new Exception("This email already exist");
            await _userRepository.AddAsync(new User()
            {
                Email = model.Email,
                HashedPassword = hashedPassword[0],
                Salt = hashedPassword[1]
            });
        }

        if (model.Phone is not null)
        {
            if (_userRepository.Table.Any(c => c.Phone == model.Phone))
                throw new Exception("This phone already exist");
            
            await _userRepository.AddAsync(new User()
            {
                Phone = model.Phone,
                HashedPassword = hashedPassword[0],
                Salt = hashedPassword[1]
            });
        }
        await _userRepository.SaveAsync();
        return true;
    }
    
    public async Task<bool> UpdateUserAsync(UpdateUser model)
    {
        var user = await _userRepository.GetSingleAsync(x => x.Id == _contextAccessor.HttpContext.User.GetId());
        if (user is null)
            throw new NotFoundUserException();
        if (model.Email != null)
        {
            if (await _userRepository.Table.AnyAsync(x => x.Email == model.Email))
                throw new Exception("This email has been taken. Use another one.");
            user.Email = model.Email;
        }
        if (model.Phone != null)
        {
            if (await _userRepository.Table.AnyAsync(x => x.Phone == model.Phone))
                throw new Exception("This phone has been taken. Use another one.");
            user.Phone = model.Phone;
        }
        if (model.CurrentPassword is not null)
        {
            if (model.NewPassword is not null)
            {
                if (model.NewPasswordConfirm is not null)
                {
                    var response = PasswordOperation.VerifyPassword(model.CurrentPassword, user.Salt, user.HashedPassword);
                    if (response)
                    {
                        var hashAndSalt = PasswordOperation.CalculateSha256Hash(model.NewPassword);
                        user.HashedPassword = hashAndSalt[0];
                        user.Salt = hashAndSalt[1];
                    }
                }
                else
                    throw new Exception(
                        "Enter new password again or left empty the current password and new password input");
            }
            else
                throw new Exception("Provide a new password or left empty the current password input");
        }
        if (model.NewPassword != model.NewPasswordConfirm)
            throw new Exception("Passwords does not match");
        await _userRepository.SaveAsync();
        return true;
    }
    
    public async Task UpdateRefreshToken(string refreshToken, User user, DateTime accessTokenExpires, int refreshTokenLifetime)
    {
        if (user is null) 
            throw new Exception("User Not Found");
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpires = accessTokenExpires.AddMinutes(refreshTokenLifetime); 
        _userRepository.Update(user);
        await _userRepository.SaveAsync();
    }
}