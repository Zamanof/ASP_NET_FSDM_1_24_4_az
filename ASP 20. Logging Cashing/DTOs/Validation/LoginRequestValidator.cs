using ASP_20._Logging_Cashing.DTOs.Auth;
using FluentValidation;

namespace ASP_20._Logging_Cashing.DTOs.Validation;
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
