using MediatR;

namespace BinaAz.Application.Features.Commands.Profile.UpdateProfile;

public class UpdateUserProfileCommandRequest : IRequest<string>
{
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? CurrentPassword { get; set; }
    public string? NewPassword { get; set; }
    public string? NewPasswordConfirm { get; set; }
}