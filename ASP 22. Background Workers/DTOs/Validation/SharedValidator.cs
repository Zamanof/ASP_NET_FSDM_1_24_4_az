using System.Text.RegularExpressions;

namespace ASP_22._Background_Workers.DTOs.Validation;

public static class SharedValidator
{
    public static bool BeValidPassword(string password)
    {
        return new Regex(@"\d").IsMatch(password)
            && new Regex(@"[a-z]").IsMatch(password)
            && new Regex(@"[A-Z]").IsMatch(password);
    }
}
