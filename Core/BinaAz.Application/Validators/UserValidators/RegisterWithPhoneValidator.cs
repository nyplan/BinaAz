using BinaAz.Application.DTOs.User;
using BinaAz.Application.Extensions;
using FluentValidation;

namespace BinaAz.Application.Validators.UserValidators;

public class RegisterWithPhoneValidator : AbstractValidator<RegisterWithPhoneDto>
{
    public RegisterWithPhoneValidator()
    {
        RuleFor(x => x.Phone)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .NullEmptyOrPhoneNumber();

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