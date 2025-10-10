using ASP_22._Background_Workers.DTOs.Auth;
using FluentValidation;

namespace ASP_22._Background_Workers.DTOs.Validation;
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
