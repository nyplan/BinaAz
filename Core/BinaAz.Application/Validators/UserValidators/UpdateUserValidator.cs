using BinaAz.Application.DTOs.User;
using BinaAz.Application.Extensions;
using FluentValidation;

namespace BinaAz.Application.Validators.UserValidators;

public class UpdateUserValidator : AbstractValidator<UpdateUser>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)! 
            .NullEmptyOrEmailAddress();
        RuleFor(x => x.Phone)
            .Cascade(CascadeMode.Stop)!
            .NullEmptyOrPhoneNumber();
        RuleFor(x => x.CurrentPassword)
            .Cascade(CascadeMode.Stop)
            .Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
            .WithMessage("The Current Password must contain at least one letter, one digit, one special character (@, $, !, %, *, ?, or &) and be at least 8 characters long.");
        RuleFor(x => x.NewPassword)
            .Cascade(CascadeMode.Stop)
            .Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
            .WithMessage("The New Password must contain at least one letter, one digit, one special character (@, $, !, %, *, ?, or &) and be at least 8 characters long.");
        RuleFor(x => x.NewPasswordConfirm)
            .Cascade(CascadeMode.Stop)
            .Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
            .WithMessage("The New Password Confirm must contain at least one letter, one digit, one special character (@, $, !, %, *, ?, or &) and be at least 8 characters long.");
    }
}