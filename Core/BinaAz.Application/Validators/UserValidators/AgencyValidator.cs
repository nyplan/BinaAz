using BinaAz.Application.Features.Commands.User.SwitchToAgency;
using FluentValidation;

namespace BinaAz.Application.Validators.UserValidators;

public class AgencyValidator : AbstractValidator<SwitchToAgencyCommandRequest>
{
    public AgencyValidator()
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

    }
}