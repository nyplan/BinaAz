using BinaAz.Application.DTOs.Item.AddUpdateItem;
using BinaAz.Application.Extensions;
using FluentValidation;

namespace BinaAz.Application.Validators.ItemValidators.AddItem;

public class OldBuildingRentValidator : AbstractValidator<OldBuildingRentDto>
{
    public OldBuildingRentValidator()
    {
        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)! 
            .NullEmptyOrEmailAddress();
        
        RuleFor(x => x.Phone)
            .Cascade(CascadeMode.Stop)!
            .NullEmptyOrPhoneNumber();

        RuleFor(x => x.Address)
            .NotNull()
            .MinimumLength(20)
            .MaximumLength(120)
            .WithMessage("The address must be between 20 and 120 characters in length.");

        RuleFor(x => x.Area)
            .NotNull()
            .GreaterThanOrEqualTo(5)
            .WithMessage("The area must be at least 5");

        RuleFor(x => x.Images)
            .NotNull()
            .Must(x => x.Count >= 4)
            .WithMessage("At least 4 images are required.");

        RuleFor(x => x.Price)
            .NotNull()
            .GreaterThanOrEqualTo(10)
            .WithMessage("The price must be greater than or equal to 10.");

        RuleFor(x => x.AdditionalInformation)
            .NotNull()
            .MaximumLength(500)
            .WithMessage("Maximum character limit is 500.");

        RuleFor(x => x.RelevantPerson)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .WithMessage("Please provide the relevant person's information.")
            .MaximumLength(50)
            .WithMessage("Maximum character limit is 50.");
        
        RuleFor(x => x.DayOrMonth)
            .NotNull()
            .NotEmpty()
            .WithMessage("Please specify whether the time unit is in days or months.");
        
        RuleFor(x => x.CountOfRoom)
            .NotNull()
            .GreaterThanOrEqualTo(1)
            .WithMessage("The count of room must be at least 1");

        RuleFor(x => x.Floor)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .GreaterThanOrEqualTo(1)
            .WithMessage("The floor number must be 1 or greater.")
            .LessThanOrEqualTo(x => x.CountOfFloor)
            .WithMessage("The floor number cannot be greater than the total count of floors.");
            
        RuleFor(x => x.CountOfFloor)
            .NotNull()
            .GreaterThanOrEqualTo(1)
            .WithMessage("The count of floors must be 1 or greater.");
    }
}