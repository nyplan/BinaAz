using BinaAz.Application.Features.Commands.Balance.IncreaseBalance;
using FluentValidation;

namespace BinaAz.Application.Validators.PaymentValidators;

public class CardValidator : AbstractValidator<IncreaseBalanceCommandRequest>
{
    public CardValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(1).WithMessage("Amount must be greater than 1");
        
        RuleFor(x => x.CardNumber)
            .NotEmpty().WithMessage("Credit card number is required.")
            .CreditCard().WithMessage("Invalid credit card number format.");

        RuleFor(x => x.Cvv)
            .NotEmpty().WithMessage("CVV is required.")
            .Matches(@"^\d{3}$").WithMessage("CVV must be a 3-digit number.");

        RuleFor(x => x.ExpireDate)
            .NotEmpty().WithMessage("Expiration date is required.")
            .NotEqual("string").WithMessage("Expire date must be month and year ( 06/2026 )")
            .Matches("^(0[1-9]|1[0-2])/(20[2-9][0-9]|19[7-9][0-9])$")
            .WithMessage("Expire date must be month and year ( 06/2026 ) and greater than 01/1970")
            .Must(BeAFutureDate).WithMessage("Card has been expired");
    }
    private bool BeAFutureDate(string expireDate)
    {
        var expire = expireDate.Split('/');
        if (expire.Length != 2)
            return false;
        if (int.Parse(expire[0]) < 1 || int.Parse(expire[1]) < 1)
            return false;
        DateTime dateTime = new DateTime();
        dateTime = dateTime.AddYears(int.Parse(expire[1]) - 1);
        dateTime = dateTime.AddMonths(int.Parse(expire[0]) - 1);
        return dateTime > DateTime.UtcNow;
    }
}