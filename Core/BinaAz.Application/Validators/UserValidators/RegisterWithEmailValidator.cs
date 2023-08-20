using BinaAz.Application.DTOs.User;
using FluentValidation;

namespace BinaAz.Application.Validators.UserValidators;

public class RegisterWithEmailValidator : AbstractValidator<RegisterWithEmailDto>
{
    public RegisterWithEmailValidator()
    {
        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .MinimumLength(8);
        
        RuleFor(x => x.PasswordConfirm)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .MinimumLength(8);
    }
}