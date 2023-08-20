using BinaAz.Application.Features.Commands.User.SwitchToResidentialComplex;
using FluentValidation;

namespace BinaAz.Application.Validators.UserValidators;

public class ResidentialComplexValidator : AbstractValidator<SwitchToResidentialComplexCommandRequest>
{
    public ResidentialComplexValidator()
    {
        RuleFor(x => x.CompanyName)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);
        
        RuleFor(x => x.RelevantPerson)
            .NotNull()
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);
        
        RuleFor(x => x.Address)
            .NotNull()
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(60);

        RuleFor(x => x.HandOverYear)
            .NotNull()
            .NotEmpty()
            .GreaterThanOrEqualTo(DateTime.UtcNow.Year);
    }
}