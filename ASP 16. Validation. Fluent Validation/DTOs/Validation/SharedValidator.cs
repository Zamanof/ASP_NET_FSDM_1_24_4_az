using System.Text.RegularExpressions;

namespace ASP_16._Validation._Fluent_Validation.DTOs.Validation;

public static class SharedValidator
{
    public static bool BeValidPassword(string password)
    {
        return new Regex(@"\d").IsMatch(password)
            && new Regex(@"[a-z]").IsMatch(password)
            && new Regex(@"[A-Z]").IsMatch(password);
    }
}
