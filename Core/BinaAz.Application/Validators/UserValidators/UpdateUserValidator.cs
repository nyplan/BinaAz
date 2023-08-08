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
    }
}