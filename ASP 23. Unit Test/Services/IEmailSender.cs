namespace ASP_23._Unit_Test.Services;

public interface IEmailSender
{
    Task SendEmail(string to, string text, string title);
}
