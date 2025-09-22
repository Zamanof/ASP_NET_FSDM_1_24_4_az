using ASP_16._Validation._Fluent_Validation.DTOs.Auth;
using FluentValidation;
using System.Text.RegularExpressions;

namespace ASP_16._Validation._Fluent_Validation.DTOs.Validation;

/// <summary>
/// 
/// </summary>
public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    /// <summary>
    /// 
    /// </summary>
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty();
        //RuleFor(x => x.Password)
        //    .Must(BeValidPassword)
        //    .MinimumLength(8)
        //    .NotEmpty();

        //RuleFor(x => x.Password)
        //   .Must(SharedValidator.BeValidPassword)
        //   .MinimumLength(8)
        //   .NotEmpty();

        RuleFor(x => x.Password)
           .Password(mustContainsDigit:false)
           .MinimumLength(8)
           .NotEmpty();
    }

    //private bool BeValidPassword(string password)
    //{
    //    return new Regex(@"\d").IsMatch(password)
    //        && new Regex(@"[a-z]").IsMatch(password)
    //        && new Regex(@"[A-Z]").IsMatch(password);
    //}
}
