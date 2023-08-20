using BinaAz.Application.Abstractions.Storages;
using BinaAz.Application.Exceptions;
using BinaAz.Application.Extensions;
using BinaAz.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BinaAz.Application.Features.Commands.User.UpdateProfilePhoto;

public class UpdateProfilePhotoCommandHandler : IRequestHandler<UpdateProfilePhotoCommandRequest, string>
{
    private readonly ILocalStorageService _storageService;
    private readonly IRepository<Domain.Entities.User> _userRepository;
    private readonly IHttpContextAccessor _contextAccessor;

    public UpdateProfilePhotoCommandHandler(ILocalStorageService storageService,
        IRepository<Domain.Entities.User> userRepository, IHttpContextAccessor contextAccessor)
    {
        _storageService = storageService;
        _userRepository = userRepository;
        _contextAccessor = contextAccessor;
    }

    public async Task<string> Handle(UpdateProfilePhotoCommandRequest request, CancellationToken cancellationToken)
    {
        if (_contextAccessor.HttpContext is null)
            throw new AuthenticationException();
        var user = await _userRepository.GetSingleAsync(x => x.Id == _contextAccessor.HttpContext.User.GetId());
        if (user is null)
            throw new UserNotFoundException();
        if (user.ImageUrl is not null)
        {
            if (_storageService.HasFile(user.ImageUrl))
                await _storageService.DeleteAsync(user.ImageUrl);
        }
        var response =
            await _storageService.UploadAsync($"profile-photos\\{user.Email ?? user.Phone}", new FormFileCollection() { request.Photo });
        user.ImageUrl = response[0];
        await _userRepository.SaveAsync();
        return "Profile photo successfully changed";
    }
}