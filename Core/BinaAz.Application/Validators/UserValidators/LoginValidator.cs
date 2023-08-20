using BinaAz.Application.Features.Commands.User.LoginUser;
using FluentValidation;

namespace BinaAz.Application.Validators.UserValidators;

public class LoginValidator : AbstractValidator<LoginUserCommandRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.EmailOrPhone)
            .NotNull()
            .NotEmpty()
            .MinimumLength(10);
        
        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty()
            .MinimumLength(8);
    }
}