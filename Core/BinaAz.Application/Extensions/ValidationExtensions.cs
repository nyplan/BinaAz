using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace BinaAz.Application.Extensions;

public static class ValidationExtensions
{
    public static IRuleBuilderOptions<T, string> NullEmptyOrEmailAddress<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Must(email => string.IsNullOrEmpty(email) || IsValidEmail(email))
            .WithMessage("The provided value must be a valid email address or empty/null.");
    }
    
    public static IRuleBuilderOptions<T, string> NullEmptyOrPhoneNumber<T>(
        this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder
            .Must(phone => string.IsNullOrEmpty(phone) || IsValidPhone(phone))
            .WithMessage("The provided value must be a valid phone number or empty/null.");
    }

    private static bool IsValidEmail(string email)
        => new EmailAddressAttribute().IsValid(email);
    
    private static bool IsValidPhone(string phone)
        => new PhoneAttribute().IsValid(phone);
}