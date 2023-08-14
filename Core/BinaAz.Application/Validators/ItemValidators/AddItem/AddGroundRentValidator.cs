using BinaAz.Application.DTOs.Item.AddItem;
using BinaAz.Application.Extensions;
using FluentValidation;

namespace BinaAz.Application.Validators.ItemValidators.AddItem;

public class AddGroundRentValidator : AbstractValidator<AddGroundRentDto>
{
    public AddGroundRentValidator()
    {
        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)! 
            .NullEmptyOrEmailAddress();
        
        RuleFor(x => x.Phone)
            .Cascade(CascadeMode.Stop)!
            .NullEmptyOrPhoneNumber();

        RuleFor(x => x.Address)
            .MinimumLength(20)
            .MaximumLength(120)
            .WithMessage("The address must be between 20 and 120 characters in length.");

        RuleFor(x => x.Area)
            .GreaterThanOrEqualTo(5)
            .WithMessage("The area must be at least 5 square units.");

        RuleFor(x => x.Images)
            .Must(x => x.Count >= 4)
            .WithMessage("At least 4 images are required.");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(10)
            .WithMessage("The price must be greater than or equal to 10.");

        RuleFor(x => x.AdditionalInformation)
            .MaximumLength(500)
            .WithMessage("Maximum character limit is 500.");

        RuleFor(x => x.RelevantPerson)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Please provide the relevant person's information.")
            .MaximumLength(50)
            .WithMessage("Maximum character limit is 50.");
        
        RuleFor(x => x.DayOrMonth)
            .NotEmpty()
            .WithMessage("Please specify whether the time unit is in days or months.");
    }
}