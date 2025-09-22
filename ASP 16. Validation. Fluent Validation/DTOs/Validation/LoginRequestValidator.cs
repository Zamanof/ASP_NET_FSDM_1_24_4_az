using ASP_16._Validation._Fluent_Validation.DTOs.Auth;
using FluentValidation;

namespace ASP_16._Validation._Fluent_Validation.DTOs.Validation;
/// <summary>
/// 
/// </summary>
public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    /// <summary>
    /// 
    /// </summary>
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email).EmailAddress().NotEmpty();
        RuleFor(x => x.Password).Password().NotEmpty();
    }
}
