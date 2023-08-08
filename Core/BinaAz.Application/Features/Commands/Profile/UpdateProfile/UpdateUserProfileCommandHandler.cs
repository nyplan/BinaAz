using BinaAz.Application.Abstractions.Services;
using MediatR;

namespace BinaAz.Application.Features.Commands.Profile.UpdateProfile;

public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommandRequest, string>
{
    private readonly IUserService _userService;

    public UpdateUserProfileCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<string> Handle(UpdateUserProfileCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _userService.UpdateUserAsync(new()
        {
            Email = request.Email,
            Phone = request.Phone,
            CurrentPassword = request.CurrentPassword,
            NewPassword = request.NewPassword,
            NewPasswordConfirm = request.NewPasswordConfirm
        });
        return response ? "Successfully updated" : "Something went wrong";
    }
}