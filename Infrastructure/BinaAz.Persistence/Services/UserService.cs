using BinaAz.Application.Abstractions.Services;
using BinaAz.Application.DTOs.User;
using BinaAz.Application.Repositories;
using BinaAz.Domain.Entities;
using BinaAz.Infrastructure.Operations;

namespace BinaAz.Persistence.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;

    public UserService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<CreateUserResponse> CreateAsync(CreateUser model)
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

        return new (){ Succeeded = true, Message = "Success" };
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