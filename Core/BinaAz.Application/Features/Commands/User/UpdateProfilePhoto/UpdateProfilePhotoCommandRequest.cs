using MediatR;
using Microsoft.AspNetCore.Http;

namespace BinaAz.Application.Features.Commands.User.UpdateProfilePhoto;

public class UpdateProfilePhotoCommandRequest : IRequest<string>
{
    public IFormFile Photo { get; set; } = null!;
}